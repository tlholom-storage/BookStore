using BookStore.Models.DataTransferObjects;
using BookStore.Models.Entities;
using BookStore.Utility.Interfaces;

namespace BookStore.Utility
{
    public class Mapper : IMapper
    {
        public User MapUserDtoToUser(UserDto userDto)
        {
            return new User
            {
                user_id = userDto.UserId,
                username = userDto.Username,
                first_name = userDto.FirstName,
                last_name = userDto.LastName,
                email = userDto.Email,
                password_hash = userDto.PasswordHash,
                user_type_id = userDto.UserTypeId,
                password_salt = userDto.PasswordSalt,
            };
        }

        public UserDto MapUserToUserDto(User user)
        {
            return new UserDto
            {
                UserId = user.user_id,
                Username = user.username,
                FirstName = user.first_name,
                LastName = user.last_name,
                Email = user.email,
                PasswordHash = user.password_hash,
                UserTypeId = user.user_type_id,
                PasswordSalt = user.password_salt,
            };
        }

        public Book MapBookDtoToBook(BookDto bookDto)
        {
            return new Book
            {
                book_id = bookDto.BookId,
                title = bookDto.Title,
                author = bookDto.Author,
                description = bookDto.Description,
                price_per_month = bookDto.PricePerMonth,
                category_id = bookDto.CategoryId,
                img = bookDto.Img,
            };
        }

        public BookDto MapBookToBookDto(Book book)
        {
            return new BookDto
            {
                BookId = book.book_id,
                Title = book.title,
                Author = book.author,
                Description = book.description,
                PricePerMonth = book.price_per_month,
                CategoryId = book.category_id,
                Img = book.img,
            };
        }

        public BookCategory MapBookCategoryDtoToBookCategory(BookCategoryDto bookCategoryDto)
        {
            return new BookCategory
            {
                category_id = bookCategoryDto.CategoryId,
                category_name = bookCategoryDto.CategoryName
            };
        }

        public BookCategoryDto MapBookCategoryToBookCategoryDto(BookCategory bookCategory)
        {
            return new BookCategoryDto
            {
                CategoryId = bookCategory.category_id,
                CategoryName = bookCategory.category_name
            };
        }

        public Payment MapPaymentDtoToPayment(PaymentDto paymentDto)
        {
            return new Payment
            {
                payment_id = paymentDto.PaymentId,
                subscription_id = paymentDto.SubscriptionId,
                payment_date = paymentDto.PaymentDate,
                amount = paymentDto.Amount,
                payment_status = paymentDto.PaymentStatus,
                payment_gateway_response = paymentDto.PaymentGatewayResponse,
                payment_method = paymentDto.PaymentMethod,
            };
        }

        public PaymentDto MapPaymentToPaymentDto(Payment payment)
        {
            return new PaymentDto
            {
                PaymentId = payment.payment_id,
                SubscriptionId = payment.subscription_id,
                PaymentDate = payment.payment_date,
                Amount = payment.amount,
                PaymentStatus = payment.payment_status,
                PaymentGatewayResponse = payment.payment_gateway_response,
                PaymentMethod = payment.payment_method,
            };
        }

        public Subscription MapSubscriptionDtoToSubscription(SubscriptionDto subscriptionDto)
        {
            return new Subscription
            {
                subscription_id = subscriptionDto.SubscriptionId,
                start_date = subscriptionDto.StartDate,
                end_date = subscriptionDto.EndDate,
                status = subscriptionDto.Status,
                book_id = subscriptionDto.BookId,
                user_id = subscriptionDto.UserId,
            };
        }

        public SubscriptionDto MapSubscriptionToSubscriptionDto(Subscription subscription)
        {
            return new SubscriptionDto
            {
                SubscriptionId = subscription.subscription_id,
                StartDate = subscription.start_date,
                EndDate = subscription.end_date,
                Status = subscription.status,
                BookId = subscription.book_id,
                UserId = subscription.user_id,
            };
        }

        public UserType MapUserTypeDtoToUserType(UserTypeDto userTypedto)
        {
            return new UserType
            {
                user_type_id = userTypedto.UserTypeId,
                user_type_name = userTypedto.UserTypeName,
                is_admin = userTypedto.IsAdmin,
                is_third_party = userTypedto.IsThirdParty
            };
        }

        public UserTypeDto MapUserTypeToUserTypeDto(UserType userType)
        {
            return new UserTypeDto
            {
                UserTypeId = userType.user_type_id,
                UserTypeName = userType.user_type_name,
                IsAdmin = userType.is_admin,
                IsThirdParty = userType.is_third_party
            };
        }
    }
}
