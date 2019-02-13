import React from 'react'
import ReactHtmlParser, { processNodes, convertNodeToElement, htmlparser2 } from 'react-html-parser';
const PackingEssentialCard = props => {
    return (
        <div className="card">
            <div className="card-body">
                {ReactHtmlParser(props.packing)}
            </div>
        </div>
    )
}
export default PackingEssentialCard