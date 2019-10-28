import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import Input from '@material-ui/core/Input';
import { Paper, IconButton, InputBase, Divider, Theme } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import SearchIcon from '@material-ui/icons/Search';
import DirectionsIcon from '@material-ui/icons/Directions';

const useStyles = makeStyles((theme: Theme) => ({
    container: {
        width: '100%',
        padding: '1em 0',
    },
    root: {
        margin: '0 auto',
        display: 'flex',
        alignSelf: 'center',
        width: '400px'
    },
    input: {
        marginLeft: theme.spacing(1),
        flex: 1,
    },
    iconButton: {
        padding: 10,
    }
}));

interface Props {
}

export const SearchCompany: React.FC<Props> = (props) => {
    const classes = useStyles();
    return (
        <div className={classes.container}>
            <Paper className={classes.root}>
                <InputBase
                    className={classes.input}
                    placeholder="NIP/KRS/REGON"
                />
                <IconButton className={classes.iconButton} aria-label="search">
                    <SearchIcon />
                </IconButton>
            </Paper>
        </div>
    )
}
