// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import MovieList from './components/MovieList';
import MovieDetail from './components/MovieDetail';
import SeatSelection from './components/SeatSelection';
import Payment from './components/Payment';

const App = () => {
  return (
    <Router>
      <div className="container">
        <h1 className="mt-4">Movie Booking App</h1>
        <Routes>
          <Route path="/" element={<MovieList />} />
          <Route path="/movie/:id" element={<MovieDetail />} />
          <Route path="/seats/:id" element={<SeatSelection />} />
          <Route path="/payment/:id" element={<Payment />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
