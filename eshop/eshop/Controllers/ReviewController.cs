using eshop.Models;
using eshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // GET: api/Review
    [HttpGet]
    public Task<IEnumerable<Review>> GetAllReviews()
    {
        return _reviewService.GetAllReviews();
    }

    // GET: api/Review/1
    [HttpGet("{id}")]
    public Task<Review?> GetReviewById(int id)
    {
        return _reviewService.GetReviewById(id);
    }

    // POST: api/Review
    [HttpPost]
    public Task<int> CreateReview(Review review)
    {
        return _reviewService.CreateReview(review);
    }

    // PUT: api/Review/1
    [HttpPut("{id}")]
    public Task<bool> UpdateReview(int id, Review review)
    {
        review.ReviewId = id;

        return _reviewService.UpdateReview(review);
    }

    // DELETE: api/Review/1
    [HttpDelete("{id}")]
    public Task<bool> DeleteReview(int id)
    {
        return _reviewService.DeleteReview(id);
    }
}