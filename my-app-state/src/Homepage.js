import React, { Component } from "react";
import { NavLink, BrowserRouter, Route, Routes } from "react-router-dom";
import UseEffectExample from "./UseEffectExample";
import Tictac from "./Tictac";
import Lift from "./Lift";
import BookSearch from "./BookSearch";
import RouteSample from "./RouteSample";
class Homepage extends Component {
  render() {
    return (
      <BrowserRouter>
        <div className="App">
          <li>
            <NavLink to="/UseEffectExample" className="btn btn-primary">
              UseEffectExample
            </NavLink>
          </li>
          <li>
            <NavLink to="/Lift" className="btn btn-primary">
              Lift State up
            </NavLink>
          </li>
          <li>
            <NavLink to="/BookSearch" className="btn btn-primary">
              Book Search
            </NavLink>
          </li>
          <li>
            <NavLink to="/Tictac" className="btn btn-primary">
              tic tac
            </NavLink>
          </li>
          <li>
            <NavLink to="/RouteSample" className="btn btn-primary">
              Routes
            </NavLink>
          </li>
          <hr />
          <Routes>
            <Route path="/UseEffectExample" element={<UseEffectExample />} />
            <Route path="/Lift" element={<Lift />} />
            <Route path="/BookSearch" element={<BookSearch />} />
            <Route path="/Tictac" element={<Tictac />} />
            <Route path="/RouteSample" element={<RouteSample />} />
          </Routes>
        </div>
      </BrowserRouter>
    );
  }
}
/*
https://programmingwithmosh.com/javascript/react-lifecycle-methods/
https://www.freecodecamp.org/news/what-is-lifting-state-up-in-react/
https://learnwithparam.com/blog/learn-react-hooks-by-building-books-search/
*/
export default Homepage;
