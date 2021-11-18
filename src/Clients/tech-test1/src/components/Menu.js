import React from "react";
import { Link } from "react-router-dom";

export class Menu extends React.Component {
  render() {
    return (
      <aside className="menu is-info">
        <p className="menu-label"> Módulo de Producto </p>
        <ul className="menu-list">
          <li><Link to="page-prod-create-feature">Registro de Caracteristicas</Link></li>
          <li><Link to="page-prod-create-merchandise">Registro de Mercancia</Link></li>
          <li><Link to="page-prod-create-product">Registro de Producto</Link></li>
        </ul>
        <p className="menu-label"> Módulo de Inventario </p>
        <ul className="menu-list">
          <li><Link to="page-inv-create-inventory">Registro de Inventario</Link></li>
          <li><Link to="page-inv-inquery-product-stock">Consulta de Existencia</Link></li>
        </ul>
      </aside>
    );
  }
}