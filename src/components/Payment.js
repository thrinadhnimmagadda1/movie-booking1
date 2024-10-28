// src/components/Payment.js
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Payment = () => {
  const navigate = useNavigate(); // Use useNavigate instead of useHistory
  const [cardNumber, setCardNumber] = useState('');
  const [expiryDate, setExpiryDate] = useState('');
  const [cvv, setCvv] = useState('');
  const [error, setError] = useState('');

  const handlePaymentSubmit = (e) => {
    e.preventDefault();
    
    // Basic validation (you can expand this)
    if (!cardNumber || !expiryDate || !cvv) {
      setError('All fields are required.');
      return;
    }

    // Mock payment processing
    alert('Payment successful! Thank you for booking your tickets.');
    
    // Redirect to home or movie list page after successful payment
    navigate('/'); // Use navigate instead of history.push
  };

  return (
    <div className="mt-4">
      <h2>Payment</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handlePaymentSubmit}>
        <div className="form-group">
          <label>Card Number</label>
          <input
            type="text"
            className="form-control"
            value={cardNumber}
            onChange={(e) => setCardNumber(e.target.value)}
            placeholder="Enter your card number"
            required
          />
        </div>
        <div className="form-group">
          <label>Expiry Date (MM/YY)</label>
          <input
            type="text"
            className="form-control"
            value={expiryDate}
            onChange={(e) => setExpiryDate(e.target.value)}
            placeholder="MM/YY"
            required
          />
        </div>
        <div className="form-group">
          <label>CVV</label>
          <input
            type="text"
            className="form-control"
            value={cvv}
            onChange={(e) => setCvv(e.target.value)}
            placeholder="Enter your CVV"
            required
          />
        </div>
        <button type="submit" className="btn btn-success mt-2">Pay Now</button>
      </form>
    </div>
  );
};

export default Payment;
