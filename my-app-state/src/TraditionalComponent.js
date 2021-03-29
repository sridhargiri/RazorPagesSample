import React from "react";

class TraditionalComponent extends React.Component {
  state = {
    buttonPressed: "",
  };

  componentDidMount() {
    console.log("Component did mount", this.state.buttonPressed)
  }

  componentDidUpdate() {
    console.log("Component did update", this.state.buttonPressed)
  }

  onYesPress() {
    this.setState({ buttonPressed: "Yes" });
  }

  onNoPress() {
    this.setState({ buttonPressed: "No" });
  }

render() {
    return (
      <div>
        <button onClick={() => this.onYesPress()}>Yes</button>
        <button onClick={() => this.onNoPress()}>No</button>
      </div>
    );
  }
}

export default TraditionalComponent;