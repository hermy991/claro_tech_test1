// import logo from './logo.svg';
import './App.css';
/** Components */
import { NavBar } from './Components/NavBar'
import { Menu } from './Components/Menu';
/** Pages */
import { PageHome, PageAbout, PageDocumentation, PageWork, PageContact, PageReportAIssue, PageProdCreateFeature, PageProdCreateMerchandise, PageProdCreateProduct, PageInvCreateInventory, PageInvInquiryProductStock } from './Pages/Pages';
import { BrowserRouter, Routes, Route} from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <div>
        <div className="app-header">
          <NavBar></NavBar>
        </div>
        <div className="app-body">
          <div className="app-menu">
            <Menu></Menu>
          </div>
          <div className="app-playground">
              <Routes>
                <Route path="/" element={<PageHome />} />
                <Route path="home/" element={<PageHome />} />
                <Route path="documentation/" element={<PageDocumentation />} />
                <Route path="about/" element={<PageAbout />} />
                <Route path="work/" element={<PageWork />} />
                <Route path="contact/" element={<PageContact />} />
                <Route path="report-a-issue/" element={<PageReportAIssue />} />
                {/* Products Pages */}
                <Route path="page-prod-create-feature/" element={<PageProdCreateFeature />} />
                <Route path="page-prod-create-merchandise/" element={<PageProdCreateMerchandise />} />
                <Route path="page-prod-create-product/" element={<PageProdCreateProduct />} />
                {/* Inventories Pages */}
                <Route path="page-inv-create-inventory/" element={<PageInvCreateInventory />} />
                <Route path="page-inv-inquery-product-stock/" element={<PageInvInquiryProductStock />} />
              </Routes>
          </div>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;
