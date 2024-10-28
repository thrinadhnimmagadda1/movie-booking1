// src/components/MovieDetail.js
import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import Review from './Review';

const MovieDetail = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [movie, setMovie] = useState(null);
  const [reviews, setReviews] = useState([]);

  useEffect(() => {
    const fetchMovie = async () => {
      try {
        const response = await axios.get(`http://localhost:5000/movies/${id}`);
        setMovie(response.data);
        setReviews(response.data.reviews || []);
      } catch (error) {
        console.error("Error fetching the movie:", error);
      }
    };

    fetchMovie();
  }, [id]);

  const handleAddReview = (movieId, reviewText) => {
    setReviews((prevReviews) => [...prevReviews, reviewText]);
  };

  const handleSeatSelection = () => {
    navigate(`/seats/${movie.id}`);
  };

  if (!movie) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h2>{movie.title}</h2>
      <img src={movie.poster} alt={movie.title} />
      <p>{movie.description}</p>
      <button className="btn btn-primary" onClick={handleSeatSelection}>
        Select Seats
      </button>
      <Review movieId={movie.id} onAddReview={handleAddReview} reviews={reviews} />
    </div>
  );
};

export default MovieDetail;
