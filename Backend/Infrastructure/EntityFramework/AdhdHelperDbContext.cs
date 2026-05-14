using Domain.Aggregates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

internal class AdhdHelperDbContext : DbContext
{
    public virtual DbSet<Challenge> Challenges { get; set; }
    public virtual DbSet<ChallengeStage> ChallengeStages { get; set; }
}