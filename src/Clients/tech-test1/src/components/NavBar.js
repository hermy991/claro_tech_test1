import React from "react";
import { Link } from "react-router-dom";

export class Navbar extends React.Component {
  render() {
    return (<nav className="navbar is-info is-fixed-top" role="navigation" aria-label="main navigation">
    <div className="navbar-brand">
      <Link className="navbar-item" to="/">
        <img src="/hermy-logo.png" alt="Hermy logo" width="112" height="28"></img>
      </Link>
  
      <Link role="button" to="#" className="navbar-burger" aria-label="menu" aria-expanded="false" data-target="navbarBasicExample">
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
      </Link>
    </div>
  
    <div id="navbarBasicExample" className="navbar-menu">
      <div className="navbar-start">
        <Link className="navbar-item" to="/"> Home </Link>
        <Link className="navbar-item" to="documentation/"> Documentación </Link>  
        <div className="navbar-item has-dropdown is-hoverable">
          <Link className="navbar-link" to="#"> Más </Link>  
          <div className="navbar-dropdown">
            <Link className="navbar-item" to="about/"> Acerca de </Link>
            <Link className="navbar-item" to="work/"> Trabajo </Link>
            <Link className="navbar-item" to="contact/"> Contacto </Link>
            <hr className="navbar-divider"></hr>
            <Link className="navbar-item" to="report-a-issue/"> Reportar un problema </Link>
          </div>
        </div>
      </div>
  
      <div className="navbar-end">
        <div className="navbar-item">
          {/* <div className="buttons">
            <a className="button is-primary">
              <strong>Sign up</strong>
            </a>
            <a className="button is-light">
              Log in
            </a>
          </div> */}
        </div>
      </div>
    </div>
  </nav>
  );
  }
}