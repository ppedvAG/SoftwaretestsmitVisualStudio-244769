namespace TDDBank.Tests
{
    public class BankAccountTests
    {
        [Fact, Trait("Category", "TDD")]
        public void NewBankAccount_ShouldHaveZeroBalance()
        {
            var account = new BankAccount();

            Assert.Equal(0, account.Balance);
        }


        [Fact, Trait("Category", "TDD")]
        public void Deposit_ShouldIncreaseBalance()
        {
            var account = new BankAccount();

            account.Deposit(100m);
        }

        [Theory, Trait("Category", "TDD")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deposit_ShouldThrowArgumentException_WhenAmountIsNegative(decimal amount)
        {
            var account = new BankAccount();

            var ex = Assert.Throws<ArgumentException>(() => account.Deposit(amount));
            Assert.Equal("Betrag muss größer als 0 sein.", ex.Message);
        }

        [Fact, Trait("Category", "TDD")]
        public void Withdraw_ShouldDecreaseBalance()
        {
            var account = new BankAccount();
            account.Deposit(100m);
            account.Withdraw(50m);

            Assert.Equal(50m, account.Balance);
        }

        [Theory, Trait("Category", "TDD")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Withdraw_ShouldThrowArgumentException_WhenAmountIsNegative(decimal amount)
        {
            var account = new BankAccount();

            var ex = Assert.Throws<ArgumentException>(() => account.Withdraw(amount));
            Assert.Equal("Betrag muss größer als 0 sein.", ex.Message);
        }

        [Fact, Trait("Category", "TDD")]
        public void Withdraw_MoreThanBalance_ShouldThrowInvalidOperationException()
        {
            var account = new BankAccount();

            account.Deposit(10m);

            var ex = Assert.Throws<InvalidOperationException>(() => account.Withdraw(20m));
            Assert.Equal("Nicht genug Geld.", ex.Message);
        }
    }
}