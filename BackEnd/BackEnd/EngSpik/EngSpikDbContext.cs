using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class EngSpikDbContext : DbContext
    {
        public EngSpikDbContext()
        {
        }

        public EngSpikDbContext(DbContextOptions<EngSpikDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Dictionary> Dictionaries { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupAccount> GroupAccounts { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<RegisterRoom> RegisterRooms { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<VideoResource> VideoResources { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<WordList> WordLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=EngSpik;user=root;password=5910Nttl520;treattinyasboolean=true", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("avatar")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.Country)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("country")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("firstName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("fullName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("lastName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Occupation)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("occupation")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("password")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Privated).HasColumnName("privated");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("username")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.HasIndex(e => e.AccountId, "id1_idx");

                entity.HasIndex(e => e.SpeakerId, "id_idx");

                entity.HasIndex(e => e.TopicId, "id_idx1");

                entity.Property(e => e.BeginAt)
                    .HasColumnType("datetime")
                    .HasColumnName("beginAt");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasColumnName("content")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AppointmentAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_appoint3");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.AppointmentSpeakers)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_appoint1");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_appoint2");
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.ToTable("Dictionary");

                entity.HasIndex(e => e.WordId, "id_idx");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.Dictionaries)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_dic_word");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.HasIndex(e => e.MessageId, "Fk_message_idx");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_message");
            });

            modelBuilder.Entity<GroupAccount>(entity =>
            {
                entity.ToTable("GroupAccount");

                entity.HasIndex(e => e.GroupId, "id_idx");

                entity.HasIndex(e => e.AccountId, "id_idx1");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.GroupAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ga");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupAccounts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ga1");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("Like");

                entity.HasIndex(e => e.WordListId, "id1_idx");

                entity.HasIndex(e => e.AccountId, "id_idx");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_like1");

                entity.HasOne(d => d.WordList)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.WordListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_like2");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.HasIndex(e => e.AccountId, "id_idx");

                entity.HasIndex(e => e.RoomId, "id_idx1");

                entity.HasIndex(e => e.GroupId, "id_idx2");

                entity.HasIndex(e => e.QuizId, "id_idx3");

                entity.HasIndex(e => e.WordListId, "id_idx4");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatAt).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("Fk_noti_account");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("Fk_noti_group");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("Fk_noti_quiz");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("Fk_noti_room");

                entity.HasOne(d => d.WordList)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.WordListId)
                    .HasConstraintName("Fk_noti_wordlist");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.HasIndex(e => e.TopicId, "id_idx");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_quiz");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("Record");

                entity.HasIndex(e => e.AccountReceiveId, "id1_idx");

                entity.HasIndex(e => e.AccountSendId, "id_idx");

                entity.Property(e => e.Src)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AccountReceive)
                    .WithMany(p => p.RecordAccountReceives)
                    .HasForeignKey(d => d.AccountReceiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_record_account1");

                entity.HasOne(d => d.AccountSend)
                    .WithMany(p => p.RecordAccountSends)
                    .HasForeignKey(d => d.AccountSendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_record_account");
            });

            modelBuilder.Entity<RegisterRoom>(entity =>
            {
                entity.ToTable("RegisterRoom");

                entity.HasIndex(e => e.AccountId, "id_idx");

                entity.HasIndex(e => e.RoomId, "id_idx1");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RegisterRooms)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_rr_account");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RegisterRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_rr_room");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasIndex(e => e.TopicId, "id_idx");

                entity.HasIndex(e => e.SpeakerId, "id_idx1");

                entity.Property(e => e.BeginAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_room_account");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_room_topic");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<VideoResource>(entity =>
            {
                entity.Property(e => e.Src)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.ToTable("Word");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Meaning)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Prononciation)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Voice)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<WordList>(entity =>
            {
                entity.ToTable("WordList");

                entity.HasIndex(e => e.WordId, "id_idx");

                entity.HasIndex(e => e.TopicId, "id_idx1");

                entity.HasIndex(e => e.AccountId, "id_idx3");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.WordLists)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_wl3");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.WordLists)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_wl2");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.WordLists)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_wl1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
