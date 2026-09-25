using Dapper;
using eshop.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eshop.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly string _connectionString;

    public ReviewRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' was not found.");
    }

    private IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public IEnumerable<Review> GetAllReviews()
    {
        using var connection = CreateConnection();

        const string sql = """
            SELECT
                ReviewId,
                ProductId,
                UserId,
                Rating,
                Comment,
                CreatedDate
            FROM Reviews
            """;

        return connection.Query<Review>(sql);
    }

    public Review? GetReviewById(int reviewId)
    {
        using var connection = CreateConnection();

        const string sql = """
            SELECT
                ReviewId,
                ProductId,
                UserId,
                Rating,
                Comment,
                CreatedDate
            FROM Reviews
            WHERE ReviewId = @ReviewId
            """;

        return connection.QueryFirstOrDefault<Review>(
            sql,
            new { ReviewId = reviewId });
    }

    public int CreateReview(Review review)
    {
        using var connection = CreateConnection();

        const string sql = """
            INSERT INTO Reviews
            (
                ProductId,
                UserId,
                Rating,
                Comment
            )
            VALUES
            (
                @ProductId,
                @UserId,
                @Rating,
                @Comment
            );

            SELECT CAST(SCOPE_IDENTITY() AS INT);
            """;

        return connection.ExecuteScalar<int>(sql, review);
    }

    public bool UpdateReview(Review review)
    {
        using var connection = CreateConnection();

        const string sql = """
            UPDATE Reviews
            SET
                Rating = @Rating,
                Comment = @Comment
            WHERE ReviewId = @ReviewId
            """;

        var rowsAffected = connection.Execute(sql, review);

        return rowsAffected > 0;
    }

    public bool DeleteReview(int reviewId)
    {
        using var connection = CreateConnection();

        const string sql = """
            DELETE FROM Reviews
            WHERE ReviewId = @ReviewId
            """;

        var rowsAffected = connection.Execute(
            sql,
            new { ReviewId = reviewId });

        return rowsAffected > 0;
    }
}