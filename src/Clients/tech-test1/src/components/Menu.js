import React from "react";

export class Menu extends React.Component {
  render() {
    return (
      <aside class="menu is-info">
        <p class="menu-label"> Módulo de Producto </p>
        <ul class="menu-list">
          <li><a>Registro de Caracteristicas</a></li>
          <li><a>Registro de Mercancia</a></li>
          <li><a>Registro de Producto</a></li>
        </ul>
        <p class="menu-label"> Módulo de Inventario </p>
        <ul class="menu-list">
          <li><a>Registro de Inventario</a></li>
          <li><a>Consulta de Existencia</a></li>
        </ul>
      </aside>
    );
  }
}