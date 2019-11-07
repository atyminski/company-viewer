import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import SearchIcon from '@material-ui/icons/Search';
import { Theme, TextField, IconButton } from '@material-ui/core';
import { Formik, FormikHelpers } from 'formik';
import * as Yup from 'yup';
import { FoundCompany } from '../model';
import settings from '../../../config';

const useStyles = makeStyles((theme: Theme) => ({
    container: {
        width: '100%',
        padding: '1em 0',
    },
    searchField: {
        width: '300px'
    },
    iconButton: {
        margin: '.8em .1em'
    }
}));

const validationSchema = Yup.object().shape({
    searchPhrase: Yup.string()
        .required("Pole nie może być puste")
        .matches(/^[A-Z\d-]+$/i, 'Pole zawiera niedozwolone znaki')
        .test('valid-format', 'Niepoprawna wartość', async (value: string): Promise<boolean> => {
            if(/^\d+$/.test(value)) {
                return (value.length === 9 || value.length === 10)
            }
            else {
                return /^[A-Z]{2}\d{10}$|^\d{3}-\d{3}-\d{2}-\d{2}$/.test(value)
            }
        })

})

interface Props {
    onBusyChanged?: (isBusy: boolean) => void
    onNewData?: (companyModel?: FoundCompany, error?: string) => void
}

interface FormValues {
    searchPhrase: string
}

export const SearchCompany: React.FC<Props> = (props) => {
    const classes = useStyles();

    const setResult = (companyModel?: FoundCompany, error?: string) => {
        if(props.onNewData) {
            props.onNewData(companyModel, error)
        }
    }

    const handleSearch = async (value: string) => {
        var response = await fetch(settings.REACT_APP_API_URL+'/companies/find?searchPhrase='+value)
        if(response.ok){
            if(response.status === 200) {
                var result = await response.json()
                setResult(result as FoundCompany)
            }
        }
        else if(response.status === 404) {
            setResult(undefined, 'Nie znaleziono danych')
        }
        else {
            throw response
        }
    }

    const onSubmit = (values: FormValues, helpers: FormikHelpers<FormValues>) => {
        const {validateForm, setSubmitting} = helpers
        const setBusy = (state: boolean) => {
            setSubmitting(state);
            if (props.onBusyChanged)
                props.onBusyChanged(state);
        };
        validateForm().then(() => {
            setBusy(true);
            handleSearch(values.searchPhrase)
                .catch(() => setResult(undefined, 'Wystąpił błąd podczas pobierania danych'))
                .finally(() => setBusy(false));
        });
    };
    return (
        <div className={classes.container}>
            <Formik
                initialValues={{ searchPhrase: '' } as FormValues}
                validationSchema={validationSchema}
                onSubmit={onSubmit}
                validateOnBlur={false}
                validateOnChange={false}
                validateOnMount={false}
            >
                {({
                    values,
                    errors,
                    touched,
                    handleChange,
                    handleBlur,
                    handleSubmit,
                    isSubmitting,
                }) => (
                        <form onSubmit={handleSubmit}>
                            <TextField
                                className={classes.searchField}
                                id="searchPhrase"
                                name="searchPhrase"
                                label="NIP/KRS/REGON"
                                error={errors.searchPhrase !== null && errors.searchPhrase !== undefined && touched.searchPhrase}
                                helperText={errors.searchPhrase}
                                margin="normal"
                                variant="outlined"
                                disabled={isSubmitting}
                                onChange={handleChange}
                                onBlur={handleBlur}
                                value={values.searchPhrase}
                            />
                            <IconButton className={classes.iconButton} disabled={isSubmitting} aria-label="search" type='submit'>
                                <SearchIcon />
                            </IconButton>
                        </form>
                    )}
            </Formik>
        </div>
    )
}
