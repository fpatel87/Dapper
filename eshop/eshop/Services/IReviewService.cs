using eshop.Models;

namespace eshop.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllReviews();

    Task<Review?> GetReviewById(int reviewId);

    Task<int> CreateReview(Review review);

    Task<bool> UpdateReview(Review review);

    Task<bool> DeleteReview(int reviewId);
}