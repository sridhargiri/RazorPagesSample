import React, {
  createContext,
  useState,
  useEffect,
  useContext,
  useReducer
} from "react";
import { render } from "react-dom";

const size = 3;

class Field {
  constructor(fieldSize) {
    this.size = fieldSize;
    this.data = new Array(this.size).fill(new Array(this.size).fill(undefined));
    this.subscribers = {};
  }

  _cellSubscriberId(rowI, cellI) {
    return `row${rowI}cell${cellI}`;
  }

  cellContent(rowI, cellI) {
    return this.data[rowI][cellI];
  }

  setCell(rowI, cellI, newContent) {
    console.log("setCell");
    this.data = [
      ...this.data.slice(0, rowI),
      [
        ...this.data[rowI].slice(0, cellI),
        newContent,
        ...this.data[rowI].slice(cellI + 1)
      ],
      ...this.data.slice(rowI + 1)
    ];
    const cellSubscriber = this.subscribers[
      this._cellSubscriberId(rowI, cellI)
    ];
    if (cellSubscriber) {
      cellSubscriber();
    }
  }

  map(cb) {
    return this.data.map(cb);
  }

  subscribeCellUpdates(rowI, cellI, onSetCellCallback) {
    this.subscribers[this._cellSubscriberId(rowI, cellI)] = onSetCellCallback;
  }

  unsubscribeCellUpdates(rowI, cellI) {
    delete this.subscribers[this._cellSubscriberId(rowI, cellI)];
  }
}

const useForceRender = () => {
  const [, forceRender] = useReducer(oldVal => oldVal + 1, 0);
  return forceRender;
};

const AppContext = createContext();

const randomContent = () => (Math.random() > 0.5 ? "x" : "0");

const cellStyle = {
  textAlign: "center",
  width: "20px",
  height: "20px",
  minWidth: "20px",
  minHeight: "20px",
  lineHeight: "20px",
  border: "1px solid black"
};
const Cell = ({ rowI, cellI }) => {
  console.log("cell render");
  const forceRender = useForceRender();
  const field = useContext(AppContext);
  useEffect(() => {
    field.subscribeCellUpdates(rowI, cellI, forceRender);
    return () => field.unsubscribeCellUpdates(rowI, cellI);
  }, [forceRender]);
  const content = field.cellContent(rowI, cellI);
  return (
    <div
      style={cellStyle}
      onClick={() => field.setCell(rowI, cellI, randomContent())}
    >
      {content}
    </div>
  );
};

const rowStyle = {
  display: "flex",
  flexDirection: "row"
};

const Tictac = () => {
  const [field] = useState(() => new Field(size));
  return (
    <AppContext.Provider value={field}>
      <div>
        {field.map((row, rowI) => (
          <div key={rowI} style={rowStyle}>
            {row.map((cell, cellI) => (
              <Cell key={`row${rowI}cell${cellI}`} rowI={rowI} cellI={cellI} />
            ))}
          </div>
        ))}
      </div>
    </AppContext.Provider>
  );
};

export default Tictac;

render(<Tictac />, document.getElementById("root"));
