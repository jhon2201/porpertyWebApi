import React, {useState, useEffect} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function App() {
  
  const baseUrl ="https://localhost:44387/api/Property";
  const baseUrlImage ="https://localhost:44387/api/PropertyImage";
  
  const [data, setData]= useState([]);
  const [dataResults, setDataResults]= useState([]);
  const [dataResultsImage, setDataResultsImage]= useState([]);
  
  const [modalInsertar, setModalInsertar]= useState(false);
  const [modalEditar, setModalEditar]= useState(false);
  const [modalBuscar, setModalBuscar]= useState(false);
  const [modalAgregarImagen, setModalAgregarImagen]= useState(false);
  
  const [propertySeleccionada, setPropertySeleccionada]= useState({
        "idProperty": 0,
        "name": '',
        "address": '',
        "price": 0.0,
        "codeInternal": '',
        "year": 0,
        "idOwner": 0
  });

  const [propertyImagen, setPropertyImagen]=useState({
    "idProperty": 0,
    "idPropertyImage":0,
    "file": '',
    "enabled": true,
  });

  const handleChange=e =>{
    const{name,value}=e.target;
    setPropertySeleccionada({
      ...propertySeleccionada, 
      [name]: value
    });
    console.log(propertySeleccionada);
  }

  const handleChangeImagen=e =>{
    const{name,value}=e.target;
    //propertyImagen.idProperty= property.idProperty ;
    setPropertyImagen({
      ...propertyImagen, 
      [name]: value
    });
    console.log(propertyImagen);
  }

  const abrirCerrarModalInsertar=()=>{
    setModalInsertar(!modalInsertar); 
  };

  const abrirCerrarModalEditar=()=>{
    setModalEditar(!modalEditar); 
  };

  const abrirCerrarModalBuscar=()=>{
    setModalBuscar(!modalBuscar); 
  };

  const abrirCerrarModalAgregarImagen=()=>{
    propertyImagen.idProperty= propertySeleccionada.idProperty;
    peticionGetImagen();
    setModalAgregarImagen(!modalAgregarImagen); 
  };

  const peticionGet =async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    });
  }

  const peticionGetFiltro =async()=>{
    await axios.get(baseUrl+"/" + propertySeleccionada.idProperty)
    .then(response=>{
      setDataResults(response.data);
    }).catch(error=>{
      console.log(error);
    });
  }

const peticionPost =async()=>{
    delete propertySeleccionada.idProperty;
    await axios.post(baseUrl, propertySeleccionada)
    .then(response=>{
      setData(data.concat(response.data));
      abrirCerrarModalInsertar();
    }).catch(error=>{
      console.log(error);
    });
  }
  
const peticionPut=async()=>{
     await axios.put(baseUrl+"/" + propertySeleccionada.idProperty, propertySeleccionada)
     .then(response=>{
       var respuesta = response.data;
       var dataAuxiliar =data;
       dataAuxiliar.map(property=>{
         if(property.idProperty === propertySeleccionada.idProperty){
           property.name = respuesta.name;
           property.address = respuesta.address;
           property.price = respuesta.price;
           property.year = respuesta.year;
           property.codeInternal = respuesta.codeInternal;
           property.idOwner = respuesta.idOwner;
         }
       });
       abrirCerrarModalEditar();
     }).catch(error=>{
       console.log(error);
     });
   }

const peticionGetImagen =async()=>{
    await axios.get(baseUrlImage+"/"+ propertyImagen.idProperty)
    .then(response=>{
      setDataResultsImage(response.data);
    }).catch(error=>{
      console.log(error);
    });
  }

const peticionPostImagen =async()=>{
  delete propertyImagen.idPropertyImage;
  await axios.post(baseUrlImage, propertyImagen)
    .then(response=>{
      setData(data.concat(response.data));
      //abrirCerrarModalAgregarImagen();
    }).catch(error=>{
      console.log(error);
    });
}

const seleccionarProperty=(property, caso)=>{
     setPropertySeleccionada(property);
   (caso ==="Editar") && abrirCerrarModalEditar();
   (caso ==="Imagen") && abrirCerrarModalAgregarImagen();
};


useEffect(()=>{
    peticionGet();
});

return (

<div className="App">
  <br /><br />
  <table>
        <tbody>
        <tr>
          <td>
            <button className="btn btn-success" onClick={()=>abrirCerrarModalInsertar()}>Insertar Propiedad</button>
          </td>
          <td>
            <button className="btn btn-warning" onClick={()=>abrirCerrarModalBuscar()}>Buscar una Propiedad</button>
            </td>
        </tr>
        </tbody>
      </table>
  <br /><br />
  <table className="table table-striped">
      <thead>
      <tr>
          <th>IdProperty</th>
          <th>Name</th>
          <th>Address</th>
          <th>Price</th>
          <th>InternalCode</th>
          <th>Year</th>
          <th>Owner</th>
          <th>Acciones</th>
      </tr>
      </thead>
      <tbody>
        {data.map(property=>(
           <tr key={property.idProperty}>
             <td>{property.idProperty}</td>
             <td>{property.name}</td>
             <td>{property.address}</td>
             <td>{property.price}</td>
             <td>{property.codeInternal}</td>
             <td>{property.year}</td>
             <td>{property.idOwner}</td>
             <td>
             <button className="btn btn-primary"  onClick={()=>seleccionarProperty(property, "Editar")}>Editar</button> {" "}
             <button className="btn btn-info"     onClick={()=>seleccionarProperty(property, "Imagen")}>Agregar Imagen</button> {" "}
             </td>
           </tr>
        ))}
      </tbody>
      </table>

<Modal isOpen={modalInsertar}>
  <ModalHeader>REGISTAR UNA PROPIEDAD</ModalHeader>
  <ModalBody>
    <div className="form-group">
      <label>Name:</label>
      <br />
      <input type="text" className="form-control" name="name" onChange={handleChange}></input>
      <br />
      <label>Address:</label>
      <br />
      <input type="text" className="form-control" name="address" onChange={handleChange}></input>
      <br />
      <label>Price:</label>
      <br />
      <input type="text" className="form-control" name="price" onChange={handleChange}></input>
      <br />
      <label>Internal Code:</label>
      <br />
      <input type="text" className="form-control" name="codeInternal" onChange={handleChange}></input>
      <br />
      <label>Year:</label>
      <br />
      <input type="text" className="form-control" name="year" onChange={handleChange}></input>
      <br />
      <label>Owner:</label>
      <br />
      <input type="text" className="form-control" name="idOwner" onChange={handleChange}></input>
      <br />
    </div>
  </ModalBody>
  <ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPost()}>Guardar</button> {" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalInsertar()}>Cancelar</button>
  </ModalFooter>
</Modal>

<Modal isOpen={modalEditar}>
  <ModalHeader>ACTUALIZAR UNA PROPIEDAD</ModalHeader>
  <ModalBody>
    <div className="form-group">
    <label>Id:</label>
      <br />
      <input type="text" className="form-control" name="idProperty" onChange={handleChange} readOnly value={propertySeleccionada && propertySeleccionada.idProperty}></input>
      <br />
      <label>Name:</label>
      <br />
      <input type="text" className="form-control" name="name" onChange={handleChange} value={propertySeleccionada && propertySeleccionada.name}></input>
      <br />
      <label>Address:</label>
      <br />
      <input type="text" className="form-control" name="address" onChange={handleChange} value={propertySeleccionada && propertySeleccionada.address}></input>
      <br />
      <label>Price:</label>
      <br />
      <input type="text" className="form-control" name="price" onChange={handleChange} value={propertySeleccionada && propertySeleccionada.price}></input>
      <br />
      <label>Internal Code:</label>
      <br />
      <input type="text" className="form-control" name="codeInternal" onChange={handleChange} value={propertySeleccionada && propertySeleccionada.codeInternal}></input>
      <br />
      <label>Year:</label>
      <br />
      <input type="text" className="form-control" name="year" onChange={handleChange} value={propertySeleccionada && propertySeleccionada.year}></input>
      <br />
      <label>Owner:</label>
      <br />
      <input type="text" className="form-control" name="idOwner" onChange={handleChange} value={propertySeleccionada && propertySeleccionada.idOwner}></input>
      <br />
    </div>
  </ModalBody>
  <ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPut()}>Editar</button> {" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalEditar()}>Cancelar</button>
  </ModalFooter>
</Modal>

<Modal isOpen={modalBuscar}>
<ModalHeader>BUSCAR UNA PROPIEDAD</ModalHeader>
  <ModalBody>
  <table className="table table-bordered" >
        <thead>
          <tr>
            <th colSpan="2">Buscar:</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td><label>ID Porperty:</label></td>
            <td>
              <input type="text" name="idProperty" onChange={handleChange} value={propertySeleccionada && propertySeleccionada.idProperty}></input>
            </td>
          </tr>
          <tr>
            <td><label>Name:</label></td>
            <td><input type="text" name="name" onChange={handleChange}/></td>
          </tr>
        </tbody>
  </table>
  <table>
    <tbody>
    <tr>
      <td>Name: </td>
      <td>{dataResults.name}</td>
    </tr>
    <tr>
      <td>Address: </td>
      <td>{dataResults.address}</td>
    </tr>
    <tr>
      <td>Price: </td>
      <td>{dataResults.price}</td>
    </tr>
    <tr>
      <td>Year: </td>
      <td>{dataResults.year}</td>
    </tr>
    </tbody>
  </table>
  </ModalBody>
  <ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionGetFiltro()}>Buscar</button> {" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalBuscar()}>Cancelar</button>
  </ModalFooter>
</Modal>

<Modal isOpen={modalAgregarImagen}>
  <ModalHeader>Agregar Imagen a una propiedad</ModalHeader>
  <ModalBody>
  <table className="table table-bordered" >
        <tbody>
          <tr>
            <td><label>Property:</label></td>
            <td><input type="text" className="form-control" name="idProperty" onChange={handleChangeImagen} readOnly value={propertyImagen && propertyImagen.idProperty}/></td>
          </tr>
          <tr>
            <td><label>Archivo:</label></td>
            <td>
              <input type="file" name="file" onChange={handleChangeImagen} value={propertyImagen && propertyImagen.file}></input>
            </td>
          </tr>
          <tr>
            <td><label>Activo:</label></td>
            <td>
              <input type="checkbox" name="enabled" onChange={handleChangeImagen} readOnly checked value={propertyImagen && propertyImagen.enabled}></input>
            </td>
          </tr>
        </tbody>
  </table>
  
  <table className="table table-bordered">
  <tbody>
  <thead>
          <tr>
            <th>Archivos Activos:</th>
          </tr>
        </thead>
        {dataResultsImage.map(propertyImagen=>(
           <tr>
             <td>{propertyImagen.file}</td>
           </tr>
        ))}
      </tbody>
  </table>

  </ModalBody>
  <ModalFooter>
  <button className="btn btn-info" onClick={()=>peticionGetImagen()}>Mostrar Imagenes</button> {" "}
  <button className="btn btn-primary" onClick={()=>peticionPostImagen()}>Guardar</button> {" "}
  <button className="btn btn-danger" onClick={()=>abrirCerrarModalAgregarImagen()}>Cancelar</button> {" "}
  </ModalFooter>
</Modal>
</div>
  );
}

export default App;
