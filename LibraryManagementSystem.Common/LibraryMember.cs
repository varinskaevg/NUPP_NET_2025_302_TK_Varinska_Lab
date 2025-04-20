using System;

namespace LibraryManagementSystem.Common
{
    public class LibraryMember
    {
        // Властивості
        public string Name { get; set; }
        public string MemberId { get; set; }
        public DateTime MembershipStartDate { get; set; }

        // Делегат
        public delegate void MembershipStartedEventHandler(string message);

        // Подія для інформування про початок членства
        public event MembershipStartedEventHandler MembershipStarted;

        // Статичне поле для лічильника членів бібліотеки
        public static int TotalMembersCount { get; set; } = 0;

        // Конструктор
        public LibraryMember(string name, string memberId, DateTime membershipStartDate)
        {
            Name = name;
            MemberId = memberId;
            MembershipStartDate = membershipStartDate;
            TotalMembersCount++;

            // Виклик події
            MembershipStarted?.Invoke($"Welcome {Name}, your membership started on {membershipStartDate.ToShortDateString()}.");
        }

        // Статичний метод
        public static void DisplayTotalMembersCount()
        {
            Console.WriteLine($"Total Members: {TotalMembersCount}");
        }
    }
}
