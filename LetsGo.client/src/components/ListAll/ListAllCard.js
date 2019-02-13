import React from 'react'

const ListAllCard = props => {
    console.log(props.parkCode)
    return (
        <div className="listAllCards">
            <div className="card" key={props.parkCode}>
                {/* card image  */}
                <img className="card-img-top" src="https://earthjustice.org/sites/default/files/styles/image_800x600/public/joshua-tree_schroptschop-getty-800.jpg?itok=cPcHzDtw" alt="Card image cap" />
                {/* card title  */}
                <div class="card-header">
                    <h3 className="card-title">{props.name}, {props.state}</h3>
                </div>
                <div className="card-body listAll">
                    {/* card body where the text area is scrollable */}
                    <h6>
                        <strong>Description:</strong>
                    </h6>
                    <p className="card-text">
                        {props.description}
                    </p>
                    <h6>
                        <strong>Weather:</strong>
                    </h6>
                    <p className="description">
                        {props.description}
                    </p>
                </div>
                {/* card footer (where the links go) */}
                <div className="card-footer text-center">
                    <a href={props.url} className="btn btn-link">{props.url}</a>
                    <button className="btn btn-sm btn-success savePark" onClick={() => props.save(props.parkCode)}>Save For Later</button>
                </div>
            </div>
        </div>
    )
}

export default ListAllCard