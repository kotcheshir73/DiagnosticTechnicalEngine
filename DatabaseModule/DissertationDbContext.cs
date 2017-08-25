using System.Data.Entity;

namespace DatabaseModule
{
	public class DissertationDbContext : DbContext
	{
		public DissertationDbContext()
		{//настройки конфигурации для entity
			Configuration.ProxyCreationEnabled = false;
			Configuration.LazyLoadingEnabled = false;
			var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
			Database.SetInitializer(new CreateDatabaseIfNotExists<DissertationDbContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RuleTrend>()
				.HasRequired(rt => rt.FuzzyLabelTo)
				.WithMany()
				.HasForeignKey(rt => rt.FuzzyLabelToId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<RuleTrend>()
				.HasRequired(rt => rt.FuzzyLabelFrom)
				.WithMany()
				.HasForeignKey(rt => rt.FuzzyLabelFromId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<RuleTrend>()
				.HasRequired(rt => rt.FuzzyTrend)
				.WithMany()
				.HasForeignKey(rt => rt.FuzzyTrendId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<StatisticsByFuzzy>()
				.HasRequired(rt => rt.EndStateFuzzyLabel)
				.WithMany()
				.HasForeignKey(rt => rt.EndStateFuzzyLabelId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<StatisticsByFuzzy>()
				.HasRequired(rt => rt.EndStateFuzzyTrend)
				.WithMany()
				.HasForeignKey(rt => rt.EndStateFuzzyTrendId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<StatisticsByFuzzy>()
				.HasRequired(rt => rt.StartStateFuzzyLabel)
				.WithMany()
				.HasForeignKey(rt => rt.StartStateFuzzyLabelId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<StatisticsByFuzzy>()
				.HasRequired(rt => rt.StartStateFuzzyTrend)
				.WithMany()
				.HasForeignKey(rt => rt.StartStateFuzzyTrendId)
				.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
		}

		public virtual DbSet<SeriesDescription> SeriesDescriptions { set; get; }

		public virtual DbSet<FuzzyLabel> FuzzyLabels { set; get; }

		public virtual DbSet<FuzzyTrend> FuzzyTrends { set; get; }

		public virtual DbSet<RuleTrend> RuleTrends { get; set; }

		public virtual DbSet<PointTrend> PointTrends { get; set; }

		public virtual DbSet<AnomalyInfo> AnomalyInfos { set; get; }

		public virtual DbSet<StatisticsByEntropy> StatisticsByEntropys { set; get; }

		public virtual DbSet<StatisticsByFuzzy> StatisticsByFuzzys { set; get; }

		public virtual DbSet<GranuleUX> GranuleUXs { get; set; }

		public virtual DbSet<GranuleFT> GranuleFTs { get; set; }

		public virtual DbSet<GranuleEntropy> GranuleEntropys { get; set; }

		public virtual DbSet<GranuleFuzzy> GranuleFuzzys { get; set; }

		public virtual DbSet<DiagnosticTest> DiagnosticTests { get; set; }

		public virtual DbSet<DiagnosticTestRecord> DiagnosticTestRecords { get; set; }

		public virtual DbSet<PointInfo> PointInfos { get; set; }
	}
}
