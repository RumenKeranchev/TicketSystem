﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Normal.Models.Users;

namespace TicketSystem.Services.Normal.Contracts
{
    public interface IUserService
    {
        Task< IEnumerable< SearchAlbumsServiceModel > > SearchAlbumsAsync( string searchTerm );

        Task< IEnumerable< SearchBandsServiceModel > > SearchBandsAsync( string searchTerm );

        Task< IEnumerable< SearchSongsServiceModel > > SearchSongsAsync( string searchTerm );

        Task< IEnumerable< SearchConcertsServiceModel > > SearchConcertsAsync( string searchTerm );

        Task< SearchEverywhereServiceModel > SearchEverywhereAsync( string searchTerm );

        Task< bool > BookTicketAsync( BookTicketServiceModel serviceModel );

        Task< IEnumerable< ListAllTicketsServiceModel > > CartAsync( string userId );

        Task< bool > PostCommentAsync( CommentOnConcertServiceModel model );

        Task< IEnumerable< ListAllCommentsServiceModel > > AllCommentsForConcertAsync( int concertId );

        Task< IEnumerable< CheckoutTicketServiceModel > > ListCheckoutAsync( List< int > ids );

        Task< bool > GetSumToCheckoutAsync( List< int > ids, decimal sum );

        Task< bool > FinalizeOrderAsync( List< int >ids );
    }
}