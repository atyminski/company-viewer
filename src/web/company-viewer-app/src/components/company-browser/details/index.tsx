import React from 'react'
import { Paper, TextField, makeStyles, Theme } from '@material-ui/core'

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        width: '500px',
        margin: '0 auto',
        padding: '2em',
        display: 'grid | inline-grid',
        //gridTemplateColumns: '20% 65% 15%',
    },
    textField: {
        marginLeft: theme.spacing(1),
        marginRight: theme.spacing(1),
    },
    name: {
        //gridColumnStart: 'col-start 0',
        width: '80%'
    }
}));

interface Props {
}

export const CompanyDetails: React.FC<Props> = (props) => {
    const classes = useStyles();
    return (
        <Paper className={classes.root}>
            <TextField
                className={classes.textField}
                label="Nazwa"
                fullWidth
                margin="normal"
                InputProps={{
                    readOnly: true,
                }}
                InputLabelProps={{
                    shrink: true,
                }}
            />
            <TextField
                className={classes.textField + " " + classes.name}
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
                className={classes.textField}
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
                className={classes.textField}
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
                className={classes.textField}
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
