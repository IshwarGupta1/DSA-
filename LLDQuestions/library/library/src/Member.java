public class Member {
    String memberId;
    String memberName;
    LibraryCard libraryCard; // LibraryCard should be assigned only by the Librarian

    public Member(String memberId, String memberName) {
        this.memberId = memberId;
        this.memberName = memberName;
    }

    public void joinLibrary(Librarian librarian, String payment) {
        librarian.addMember(this, payment);
    }

    public void leaveLibrary(Librarian librarian) {
        librarian.removeMember(this);
    }

    public void borrowBook(Librarian librarian, Book book) {
        librarian.issueBook(this, book);
    }

    public void returnOrRenewBook(Librarian librarian, Book book, Boolean renew, String payment) {
        librarian.takeOrRenewBook(this, book, renew, payment);
    }
}
