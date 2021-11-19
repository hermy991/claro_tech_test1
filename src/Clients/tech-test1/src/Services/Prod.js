const pathBase = "api/v1/prod"
const options = { 
  method: 'POST', 
  headers: {
    'Content-Type': 'application/json'
  },
}

export async function getFeatures(body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  const r = await fetch(`${pathBase}/entities/Feature`, toptions);
  const json = await r.json();
  return json;
}

export async function getFeactureDetails(body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  const r = await fetch(`${pathBase}/entities/FeactureDetail`, toptions);
  const json = await r.json();
  return json;
}

export async function getMerchandises(body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  
  const r = await fetch(`${pathBase}/entities/Merchandise`, toptions);
  const json = await r.json();
  return json;
}

export async function getMerchandiseFeatures(body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  const r = await fetch(`${pathBase}/entities/MerchandiseFeature`, toptions);
  const json = await r.json();
  return json;
}

export async function getProducts(body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  const r = await fetch(`${pathBase}/entities/Product`, toptions);
  const json = await r.json();
  return json;
}

export async function getProductFeatures(body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  const r = await fetch(`${pathBase}/entities/ProductFeature`, toptions);
  const json = await r.json();
  return json;
}

export async function saveFeature(body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  const r = await fetch(`${pathBase}/process/saveFeature`, toptions);
  const json = await r.json();
  return json;
}