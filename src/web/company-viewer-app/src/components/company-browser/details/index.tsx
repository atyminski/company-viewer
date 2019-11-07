import React from 'react'
import { Paper, TextField, makeStyles, Theme } from '@material-ui/core'
import { FoundCompany } from '../model';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        padding: '2em',
        display: 'grid',
        gridTemplateColumns: '30% 50% 15%',
        gridGap: '1em'
    },
    name: {
        gridColumn: '1/4',
        gridRow: 1,
    },
    street: {
        gridColumn: '1/3',
        gridRow: 2,
    },
    number: {
        gridColumn: 3,
        gridRow: 2,
    },
    postalCode: {
        gridColumn: 1,
        gridRow: 3,
    },
    city: {
        gridColumn: '2/4',
        gridRow: 3,
    }
}));

interface Props {
    data?: FoundCompany
}

export const CompanyDetails: React.FC<Props> = (props) => {
    const classes = useStyles()
    console.log(props)
    const name = props.data ? props.data.name : ''
    const street = props.data ? props.data.street : ''
    const number = props.data ? (props.data.appartmentNumber ? [props.data.houseNumber, props.data.appartmentNumber].join('/') : props.data.houseNumber) : ''
    const postalCode = props.data ? props.data.postalCode : ''
    const city = props.data ? props.data.city : ''
    return (
        <div className={classes.root}>
            <TextField
                className={classes.name}
                label="Nazwa"
                value={name}
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                className={classes.street}
                value={street}
                label="Ulica"
                margin="normal"
                fullWidth
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                className={classes.number}
                value={number}
                label="Nr"
                margin="normal"
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                className={classes.postalCode}
                value={postalCode}
                label="Kod pocztowy"
                margin="normal"
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                className={classes.city}
                value={city}
                label="Miasto"
                margin="normal"
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
        </div>
    )
}
