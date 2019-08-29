using DTE_Model_Level.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DTE_Implement_Level
{
    public class DissertationDbContext : DbContext
	{
        public DissertationDbContext(DbContextOptions<DissertationDbContext> options) : base(options) { }

        public DissertationDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=CHESHIR\SQLEXPRESS_2012;Initial Catalog=SeriesDatabaseDissertation;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //	modelBuilder.Entity<RuleTrend>()
        //		.HasRequired(rt => rt.FuzzyLabelTo)
        //		.WithMany()
        //		.HasForeignKey(rt => rt.FuzzyLabelToId)
        //		.WillCascadeOnDelete(false);

        //	modelBuilder.Entity<RuleTrend>()
        //		.HasRequired(rt => rt.FuzzyLabelFrom)
        //		.WithMany()
        //		.HasForeignKey(rt => rt.FuzzyLabelFromId)
        //		.WillCascadeOnDelete(false);

        //	modelBuilder.Entity<RuleTrend>()
        //		.HasRequired(rt => rt.FuzzyTrend)
        //		.WithMany()
        //		.HasForeignKey(rt => rt.FuzzyTrendId)
        //		.WillCascadeOnDelete(false);

        //	modelBuilder.Entity<StatisticsByFuzzy>()
        //		.HasRequired(rt => rt.EndStateFuzzyLabel)
        //		.WithMany()
        //		.HasForeignKey(rt => rt.EndStateFuzzyLabelId)
        //		.WillCascadeOnDelete(false);

        //	modelBuilder.Entity<StatisticsByFuzzy>()
        //		.HasRequired(rt => rt.EndStateFuzzyTrend)
        //		.WithMany()
        //		.HasForeignKey(rt => rt.EndStateFuzzyTrendId)
        //		.WillCascadeOnDelete(false);

        //	modelBuilder.Entity<StatisticsByFuzzy>()
        //		.HasRequired(rt => rt.StartStateFuzzyLabel)
        //		.WithMany()
        //		.HasForeignKey(rt => rt.StartStateFuzzyLabelId)
        //		.WillCascadeOnDelete(false);

        //	modelBuilder.Entity<StatisticsByFuzzy>()
        //		.HasRequired(rt => rt.StartStateFuzzyTrend)
        //		.WithMany()
        //		.HasForeignKey(rt => rt.StartStateFuzzyTrendId)
        //		.WillCascadeOnDelete(false);

        //          base.OnModelCreating(modelBuilder);
        //}

        /// <summary>
        /// Удаления для диагностического теста и временного ряда
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var entrieDTs = ChangeTracker.Entries<DiagnosticTest>();
            foreach(var entry in entrieDTs)
            {
                if(entry.State == EntityState.Deleted)
                {
                    var entity = entry.Entity;

                    DiagnosticTestRecords.RemoveRange(DiagnosticTestRecords.Where(rec => rec.DiagnosticTestId == entity.Id));
                    GranuleFuzzys.RemoveRange(GranuleFuzzys.Where(rec => rec.DiagnosticTestId == entity.Id));
                    GranuleEntropys.RemoveRange(GranuleEntropys.Where(rec => rec.DiagnosticTestId == entity.Id));
                    GranuleUXs.RemoveRange(GranuleUXs.Where(rec => rec.DiagnosticTestId == entity.Id));
                    GranuleFTs.RemoveRange(GranuleFTs.Where(rec => rec.DiagnosticTestId == entity.Id));
                    PointInfos.RemoveRange(PointInfos.Where(rec => rec.DiagnosticTestId == entity.Id));
                }
            }
            var entrieSDs = ChangeTracker.Entries<SeriesDescription>();
            foreach (var entry in entrieSDs)
            {
                if (entry.State == EntityState.Deleted)
                {
                    var entity = entry.Entity;

                    var diagnosticsTests = DiagnosticTests.Where(rec => rec.SeriesDiscriptionId == entity.Id).Select(rec => rec.Id).ToList();

                    DiagnosticTestRecords.RemoveRange(DiagnosticTestRecords.Where(rec => diagnosticsTests.Contains(rec.DiagnosticTestId)));
                    Granules.RemoveRange(Granules.Where(rec => diagnosticsTests.Contains(rec.DiagnosticTestId)));
                    GranuleFuzzys.RemoveRange(GranuleFuzzys.Where(rec => diagnosticsTests.Contains(rec.DiagnosticTestId)));
                    GranuleEntropys.RemoveRange(GranuleEntropys.Where(rec => diagnosticsTests.Contains(rec.DiagnosticTestId)));
                    GranuleUXs.RemoveRange(GranuleUXs.Where(rec => diagnosticsTests.Contains(rec.DiagnosticTestId)));
                    GranuleFTs.RemoveRange(GranuleFTs.Where(rec => diagnosticsTests.Contains(rec.DiagnosticTestId)));
                    PointInfos.RemoveRange(PointInfos.Where(rec => diagnosticsTests.Contains(rec.DiagnosticTestId)));
                    DiagnosticTestRecords.RemoveRange(DiagnosticTestRecords.Where(rec => rec.DiagnosticTestId == entity.Id));
                    DiagnosticTests.RemoveRange(DiagnosticTests.Where(rec => rec.SeriesDiscriptionId == entity.Id));
                    StatisticsByEntropys.RemoveRange(StatisticsByEntropys.Where(rec => rec.SeriesDiscriptionId == entity.Id));
					StatisticsByFuzzys.RemoveRange(StatisticsByFuzzys.Where(rec => rec.SeriesDiscriptionId == entity.Id));
					AnomalyInfos.RemoveRange(AnomalyInfos.Where(rec => rec.SeriesDiscriptionId == entity.Id));
                    PointTrends.RemoveRange(PointTrends.Where(rec => rec.SeriesDiscriptionId == entity.Id));
                    RuleTrends.RemoveRange(RuleTrends.Where(rec => rec.SeriesDiscriptionId == entity.Id));
                    FuzzyTrends.RemoveRange(FuzzyTrends.Where(rec => rec.SeriesDiscriptionId == entity.Id));
                    FuzzyLabels.RemoveRange(FuzzyLabels.Where(rec => rec.SeriesDiscriptionId == entity.Id));
                }
            }

            return base.SaveChanges();
        }

		public virtual DbSet<SeriesDescription> SeriesDescriptions { set; get; }

		public virtual DbSet<FuzzyLabel> FuzzyLabels { set; get; }

		public virtual DbSet<FuzzyTrend> FuzzyTrends { set; get; }

		public virtual DbSet<RuleTrend> RuleTrends { get; set; }

		public virtual DbSet<PointTrend> PointTrends { get; set; }

		public virtual DbSet<AnomalyInfo> AnomalyInfos { set; get; }

		public virtual DbSet<StatisticsByEntropy> StatisticsByEntropys { set; get; }

		public virtual DbSet<StatisticsByFuzzy> StatisticsByFuzzys { set; get; }

        public virtual DbSet<Granule> Granules { get; set; }

        public virtual DbSet<GranuleUX> GranuleUXs { get; set; }

		public virtual DbSet<GranuleFT> GranuleFTs { get; set; }

		public virtual DbSet<GranuleEntropy> GranuleEntropys { get; set; }

		public virtual DbSet<GranuleFuzzy> GranuleFuzzys { get; set; }

		public virtual DbSet<DiagnosticTest> DiagnosticTests { get; set; }

		public virtual DbSet<DiagnosticTestRecord> DiagnosticTestRecords { get; set; }

		public virtual DbSet<PointInfo> PointInfos { get; set; }

        public virtual DbSet<ExperimentFileResult> ExperimentFileResults { get; set; }

        public virtual DbSet<LogData> LogDatas { get; set; }
    }
}