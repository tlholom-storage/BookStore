using BookStore.Models.DataTransferObjects;
using BookStore.Models.Entities;

namespace BookStore.Utility.Interfaces
{
    public interface IMapper
    {
        // User Mappings
        User MapUserDtoToUser(UserDto userDto);
        UserDto MapUserToUserDto(User user);

        // Book Mappings
        Book MapBookDtoToBook(BookDto bookDto);
        BookDto MapBookToBookDto(Book book);

        // BookCategory Mappings
        BookCategory MapBookCategoryDtoToBookCategory(BookCategoryDto bookCategoryDto);
        BookCategoryDto MapBookCategoryToBookCategoryDto(BookCategory bookCategory);

        // Payment Mappings
        Payment MapPaymentDtoToPayment(PaymentDto paymentDto);
        PaymentDto MapPaymentToPaymentDto(Payment payment);

        // Subscription Mappings
        Subscription MapSubscriptionDtoToSubscription(SubscriptionDto subscriptionDto);
        SubscriptionDto MapSubscriptionToSubscriptionDto(Subscription subscription);

        // UserType Mappings
        UserType MapUserTypeDtoToUserType(UserTypeDto userTypedto);
        UserTypeDto MapUserTypeToUserTypeDto(UserType userType);
    }
}
