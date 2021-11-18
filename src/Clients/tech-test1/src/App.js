// import logo from './logo.svg';
import './App.css';
import { NavBar } from './components/NavBar'
import { Menu } from './components/Menu';

function App() {
  return (
    <div>
      <div className="app-header">
        <NavBar></NavBar>
      </div>
      <div className="app-body">
        <div className="app-menu">
          <Menu></Menu>
        </div>
        <div className="app-playground">

        </div>
      </div>
    </div>
  );
}

export default App;
