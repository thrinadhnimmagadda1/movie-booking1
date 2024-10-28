// src/components/SeatSelection.js
import React, { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import './SeatSelection.css'; // Create a CSS file for styling

const SeatSelection = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [selectedSeats, setSelectedSeats] = useState([]);

  // Sample seat layout: 5 rows, 8 seats per row
  const seats = Array.from({ length: 5 }, () => Array.from({ length: 8 }, () => false));

  const toggleSeatSelection = (rowIndex, seatIndex) => {
    const seatId = `${rowIndex}-${seatIndex}`;
    setSelectedSeats((prevSelectedSeats) => {
      if (prevSelectedSeats.includes(seatId)) {
        return prevSelectedSeats.filter((seat) => seat !== seatId);
      } else {
        return [...prevSelectedSeats, seatId];
      }
    });
  };

  const handleProceedToPayment = () => {
    navigate(`/payment/${id}`, { state: { selectedSeats } });
  };

  return (
    <div>
      <h3>Select Seats</h3>
      <div className="seat-layout">
        {seats.map((row, rowIndex) => (
          <div key={rowIndex} className="seat-row">
            {row.map((_, seatIndex) => {
              const seatId = `${rowIndex}-${seatIndex}`;
              const isSelected = selectedSeats.includes(seatId);
              return (
                <button
                  key={seatId}
                  className={`seat ${isSelected ? 'selected' : ''}`}
                  onClick={() => toggleSeatSelection(rowIndex, seatIndex)}
                >
                  {seatIndex + 1}
                </button>
              );
            })}
          </div>
        ))}
      </div>
      <button
        className="btn btn-primary mt-4"
        onClick={handleProceedToPayment}
        disabled={selectedSeats.length === 0}
      >
        Proceed to Payment
      </button>
    </div>
  );
};

export default SeatSelection;
