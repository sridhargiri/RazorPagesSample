import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { Global, css } from "@emotion/core";
import normalize from "normalize.css";
import { ThemeProvider } from "emotion-theming";

import theme from "./components/theme";
import SearchPage from "./pages/searchPage.js";
import BookDetailPage from "./pages/bookDetailPage";
import "./App.css";

const NoMatchRoute = () => <div>404 Page</div>;

const BookSearch = () => {
  return (
    <ThemeProvider theme={theme}>
      <Global
        styles={css`
          ${normalize}
          body {
            background-color: #fafafa;
          }
        `}
      />
      <Router>
        <Routes>
          <Route path="/BookSearch" exact element={<SearchPage />} />
          <Route path="/book/:bookId" exact element={<BookDetailPage />} />
          <Route element={<NoMatchRoute />} />
        </Routes>
      </Router>
    </ThemeProvider>
  );
};

export default BookSearch;
