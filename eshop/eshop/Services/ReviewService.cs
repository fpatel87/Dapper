using eshop.Models;
using eshop.Repositories;

namespace eshop.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public Task<IEnumerable<Review>> GetAllReviews()
    {
        var reviews = _reviewRepository.GetAllReviews();

        return Task.FromResult(reviews);
    }

    public Task<Review?> GetReviewById(int reviewId)
    {
        var review = _reviewRepository.GetReviewById(reviewId);

        return Task.FromResult(review);
    }

    public Task<int> CreateReview(Review review)
    {
        var reviewId = _reviewRepository.CreateReview(review);

        return Task.FromResult(reviewId);
    }

    public Task<bool> UpdateReview(Review review)
    {
        var result = _reviewRepository.UpdateReview(review);

        return Task.FromResult(result);
    }

    public Task<bool> DeleteReview(int reviewId)
    {
        var result = _reviewRepository.DeleteReview(reviewId);

        return Task.FromResult(result);
    }
}