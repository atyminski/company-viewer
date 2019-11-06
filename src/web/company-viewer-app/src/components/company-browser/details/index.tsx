import React from 'react'
import { Paper, TextField, makeStyles, Theme } from '@material-ui/core'

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        width: '500px',
        margin: '0 auto',
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
}

export const CompanyDetails: React.FC<Props> = (props) => {
    const classes = useStyles();
    return (
        <Paper className={classes.root}>
            <TextField
                className={classes.name}
                label="Nazwa"
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                className={classes.street}
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
                label="Miasto"
                margin="normal"
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
        </Paper>
    )
}
