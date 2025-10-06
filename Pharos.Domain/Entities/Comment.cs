using System;
using Pharos.Domain.Common;
using Pharos.Domain.ValueObjects;

namespace Pharos.Domain.Entities;

public class Comment : EntityBase
{

    public Guid UserId { get; private set; }
    public Guid PhotoId { get; private set; }
    public string Content { get;private set; }
    public DateTime CreatedAt { get;private set; } 
    public Rating Rating { get;private set; }
    protected Comment() { }
    public Comment(Guid userId, Guid photoId, string content, Rating rating)
    {
        UserId = userId;
        PhotoId = photoId;
        Content = content;
        Rating = rating;
        CreatedAt = DateTime.UtcNow;
    }
}
