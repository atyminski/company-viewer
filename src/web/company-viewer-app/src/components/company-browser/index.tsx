import React from 'react'
import { CompanyDetails } from './details'
import { SearchCompany } from './search'
import { Container } from '@material-ui/core'

interface Props {
}

export const CompanyBrowser: React.FC<Props> = (props) => {
    return (
        <Container fixed>
            <SearchCompany />
            <CompanyDetails />
        </Container>
    )
}
