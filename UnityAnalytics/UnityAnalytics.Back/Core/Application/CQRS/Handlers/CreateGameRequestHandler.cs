using MediatR;
using UnityAnalytics.Back.Core.Application.CQRS.Commands;
using UnityAnalytics.Back.Core.Application.Dto;
using UnityAnalytics.Back.Core.Application.Interfaces;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Core.Application.CQRS.Handlers;

public class CreateGameRequestHandler : IRequestHandler<CreateGameCommandRequest,CreateGameResponseDto>
{
    private readonly IRepository<Game> _gameRepository;
    private readonly IRepository<AppUser> _userRepository;

    public CreateGameRequestHandler(IRepository<Game> gameRepository, IRepository<AppUser> userRepository)
    {
        _gameRepository = gameRepository;
        _userRepository = userRepository;
    }

    public async Task<CreateGameResponseDto> Handle(CreateGameCommandRequest request, CancellationToken cancellationToken)
    {
        var user =await _userRepository.GetByFilter(x => x.Id == request.UserId);
        if (user == null)
        {
            return new CreateGameResponseDto()
            {
                IsSuccess = false
            };
        }

        var game =await _gameRepository.GetByFilter(x => x.Name == request.GameName);

        if (game != null)
        {
            return new CreateGameResponseDto()
            {
                IsSuccess = false
            };
        }

        game = new Game()
        {
            Name = request.GameName,
            UserId = request.UserId,
        };
        await _gameRepository.CreateAsync(game);

        var responseDto = new CreateGameResponseDto()
        {
            IsSuccess = true,
            GameId = game.Id,
            GameName = game.Name
        };
        return responseDto;
    }
}