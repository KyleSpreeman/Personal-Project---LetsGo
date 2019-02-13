import React from 'react'
import { Card, CardImg, CardText, CardBody, CardTitle, Button } from 'reactstrap'

const MyParksCards = props => {
    return (
        <React.Fragment>
            <div className="HomeCards">
                <div className="card">
                    {/* card image top */}
                    <img className="card-img-top homeCardImage" src={'https://www.adlibbing.org/wp-content/uploads/2018/08/discover-the-forest-geocaching-1024x576.jpg'} alt="Card image cap" />
                    {/* card header  */}
                    <div className="card-header">
                        <h3 className="card-title">{props.name}</h3>
                    </div>
                    {/* card body for the card text */}
                    <div className="card-body listHome">
                        <h6>
                            <strong>Description:</strong>
                        </h6>
                        <p className="card-text">
                            {props.description}
                        </p>
                    </div>
                    {/* card footer where the links will go */}
                    <div className="card-footer text-center">
                        <a href={props.website} className="btn btn-link">{props.website}</a>
                        <button className="btn btn-danger btn-sm" onClick={() => props.delete(props.parkCode)}>Remove Park</button>
                    </div>
                </div>
            </div>
        </React.Fragment>
    )
}

export default MyParksCards