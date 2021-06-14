import React, { Component } from "react";
import { Link, NavLink, BrowserRouter, Route, Switch } from "react-router-dom";
import UseEffectExample from "./UseEffectExample";
import Lift from "./Lift";
import BookSearch from "./BookSearch";
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
          <hr />
          <Switch>
            <Route path="/UseEffectExample" component={UseEffectExample} />
            <Route path="/Lift" component={Lift} />
            <Route path="/BookSearch" component={BookSearch} />
          </Switch>
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
