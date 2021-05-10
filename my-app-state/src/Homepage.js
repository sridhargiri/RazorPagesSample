import React, { Component } from 'react';
import {Link,BrowserRouter, Route, Switch} from 'react-router-dom';
import UseEffectExample from './UseEffectExample'
class Homepage extends Component {
  render() {
        return (
          <BrowserRouter>
            <div className="App">
          <Link to="/UseEffectExample" className="btn btn-primary">UseEffectExample</Link>
                <Switch>  <Route path="/UseEffectExample" component={UseEffectExample}/> 
                  </Switch>

         </div>   
       </BrowserRouter>
       ); 
    }
}

export default Homepage;