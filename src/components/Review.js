// src/components/Review.js
import React, { useState } from 'react';

const Review = ({ movieId, onAddReview, reviews }) => {
  const [reviewText, setReviewText] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (reviewText) {
      onAddReview(movieId, reviewText);
      setReviewText('');
    }
  };

  return (
    <div>
      <h3>Reviews</h3>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <textarea
            className="form-control"
            rows="3"
            value={reviewText}
            onChange={(e) => setReviewText(e.target.value)}
            placeholder="Write your review here..."
            required
          />
        </div>
        <button type="submit" className="btn btn-primary mt-2">Submit Review</button>
      </form>
      <div className="mt-3">
        <h4>Existing Reviews:</h4>
        <ul className="list-unstyled">
          {reviews.map((review, index) => (
            <li key={index} className="border p-2 my-1">
              {review}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Review;
