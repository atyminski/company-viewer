import React, { useState } from 'react'
import { CompanyDetails } from './details'
import { SearchCompany } from './search'
import { makeStyles, Theme, Paper, CircularProgress } from '@material-ui/core'
import { FoundCompany } from './model';

const useStyles = makeStyles((theme: Theme) => ({
    containter: {
        width: '500px',
        margin: '0 auto',
    },
    error: {
        color: theme.palette.error.main
    }
}));

interface DataState {
    error?: string
    data?: FoundCompany
}

export const CompanyBrowser: React.FC = () => {
    const [dataState, setDataState] = useState({data: undefined, error: undefined} as DataState)
    const [busyState, setBusyState] = useState(false)
    const classes = useStyles();
    const handleBusyState = (value: boolean) => setBusyState(value)
    const handleNewData = (companyModel?: FoundCompany, error?: string) => setDataState({
        data: companyModel,
        error: error
    })
    return (
        <>
            <SearchCompany onBusyChanged={handleBusyState} onNewData={handleNewData} />
            { busyState ? <CircularProgress /> : null }
            {(dataState.data || dataState.error) && !busyState ?
                <Paper className={classes.containter}>
                    <span className={classes.error}>{dataState.error}</span>
                    <CompanyDetails data={dataState.data}/>
                </Paper>
            : null} 
        </>
    )
}
