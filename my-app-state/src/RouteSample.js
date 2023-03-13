import React, { Fragment } from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

export default function RouteSample() {
  return (
    <Router>
      <Fragment>
        <div>
          <nav>
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/about">About</Link>
              </li>
              <li>
                <Link to="/users">Users</Link>
              </li>
            </ul>
          </nav>

          {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. 
[Home] is not a Route component. All component children of Routes must be a Route or <React.Fragment>

https://stackoverflow.com/questions/69975792/error-home-is-not-a-route-component-all-component-children-of-routes-mus

*/}
          <Routes>
            <Route path="/About" element={<About />} />

            <Route path="/Users" element={<Users />} />
            <Route path="/" element={<Home />} />
          </Routes>
        </div>
      </Fragment>
    </Router>
  );
}

function Home() {
  return <h2>Home</h2>;
}

function About() {
  return <h2>About</h2>;
}

function Users() {
  return <h2>Users</h2>;
}
