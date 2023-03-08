const options = ['rock', 'paper', 'scissors'];

function onPlayed(choice) {
    let playerOneChoice = choice ? choice : getRandomChoice();
    let playerTwoChoice = getRandomChoice();

    colorChoice(playerOneChoice, playerTwoChoice);

    $.ajax({
        type: "POST",
        url: "Game/Result",
        data: { playerOneChoice, playerTwoChoice },
        success: function (data) {
            $('.result-view').html(data);

            setTimeout(function () {
                resetScreen(playerOneChoice, playerTwoChoice);
            }, 2000);
        },
        error: function (req, status, error) {
            console.log(error);
        }
    });
}

function getRandomChoice() {
    let random = Math.floor(Math.random() * options.length);
    return options[random];
}

function colorChoice(playerOneChoice, playerTwoChoice) {
    $(`#player1 #btn-${playerOneChoice}`)
        .attr('class', 'btn btn-info');

    $(`#player2 #btn-${playerTwoChoice}`)
        .attr('class', 'btn btn-info');
}

function resetScreen(playerOneChoice, playerTwoChoice) {
    $(`#player1 #btn-${playerOneChoice}`)
        .attr('class', 'btn btn-primary');

    $(`#player2 #btn-${playerTwoChoice}`)
        .attr('class', 'btn btn-primary');
}

function startPlay() {
    onPlayed();
    setTimeout(startPlay, 4000);
}