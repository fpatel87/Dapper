using eshop.Models;

namespace eshop.Repositories;

public interface IReviewRepository
{
    IEnumerable<Review> GetAllReviews();

    Review? GetReviewById(int reviewId);

    int CreateReview(Review review);

    bool UpdateReview(Review review);

    bool DeleteReview(int reviewId);
}