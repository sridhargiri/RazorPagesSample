import React ,{Component} from "react";
export  class Demo extends Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: [],
      providers: []
    };
  }

  componentDidMount() {
    fetch("https://localhost:44367/api/data/services")
      .then(res => res.json())
      .then(
        (result) => {

          this.setState({
            isLoaded: true,
            items: result.data
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      )

    fetch("https://localhost:44367/api/data/providers")
      .then(res => res.json())
      .then(
        (result) => {

          this.setState({
            isLoaded: true,
            providers: result.data
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      )
  }
     

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else {
      return (
        <ul>
          {items.map((item,index) => (
            <li key={index}>
              {item.id} {item.type}
            </li>
          ))}
        </ul>
      );
    }
  }
}