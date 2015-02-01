function PayCoin(coin, machine) {
    var url = 'handlers/PayCoin.ashx';
    var userBug = this;
    $.getJSON(url, { 'coin': JSON.stringify(coin) })
        .done(function (data) {
            if (data.Result) {
                SetMachineUserSum(machine, data.UserSumRur);
                userBug.RemoveCoin(coin);
            }
            else {
                alert("Ошибка во время выполнения операции.");
            }
        });
}

function SetMachineUserSum(machine, userSum) {
    machine.UserSumRur = userSum;
    $("#idMachineUserBug").html(machine.UserSumRur);
}

function InitUserBug(userBug) {
    $("#idUserBugOne").html(userBug.OneRurPort.Count);
    if (userBug.OneRurPort.Count > 0) {
        $("#idUserBugOne").closest("div").prop("disabled", false);
    }
    $("#idUserBugTwo").html(userBug.TwoRurPort.Count);
    if (userBug.TwoRurPort.Count > 0) {
        $("#idUserBugTwo").closest("div").prop("disabled", false);
    }
    $("#idUserBugFive").html(userBug.FiveRurPort.Count);
    if (userBug.FiveRurPort.Count > 0) {
        $("#idUserBugFive").closest("div").prop("disabled", false);
    }
    $("#idUserBugTen").html(userBug.TenRurPort.Count);
    if (userBug.TenRurPort.Count > 0) {
        $("#idUserBugTen").closest("div").prop("disabled", false);
    }
}

function InitMachine(machine) {
    $("#idTea").html(machine.TeaPort.ProductCount);
    $("#idCoffee").html(machine.CoffeePort.ProductCount);
    $("#idCoffeeAndMilk").html(machine.CoffeeAndMilkPort.ProductCount);
    $("#idJuice").html(machine.JuicePort.ProductCount);
    $("#idMachineUserBug").html(machine.UserSumRur);
    $("#idMachineUserBug").html(0);
}

function AddCoin(userBug, coin) {
    var idViewBox = coinPort(coin.Value);
    idViewBox.coinPort.Count += 1;
    $("#" + idViewBox.idBox).html(idViewBox.idBox);
    
}

function RemoveCoin(coin) {
    var idViewBox = coinPort(this, coin);

    idViewBox.coinPort.Count -= 1;
    var countBoxId = "#" + idViewBox.idBox;
    $(countBoxId).html(idViewBox.coinPort.Count);
    
    if (idViewBox.coinPort.Count == 0) {
        var buttonBox = $(countBoxId).closest("div").find(".buy-box");
        if (buttonBox.length > 0)
            buttonBox.prop("disabled", true);
    }

}

function coinPort(userBug, coin) {
    var idViewBox = {};
    switch (coin.Value) {
        case 1:
            idViewBox = {
                "coinPort": userBug.OneRurPort,
                "idBox": 'idUserBugOne'
            };
            break;
        case 2:
            idViewBox = {
                "coinPort": userBug.TwoRurPort,
                "idBox": 'idUserBugTwo'
            };
            break;
        case 5:
            idViewBox = {
                "coinPort": userBug.FiveRurPort,
                "idBox": 'idUserBugFive'
            };
            break;
        case 10:
            idViewBox = {
                "coinPort":
                    userBug.TenRurPort,
                "idBox": 'idUserBugTen'
            };
            break;
    };
    return idViewBox;
}

function BuyProduct(productType) {
    
    var url = 'handlers/Machine.ashx';
    var machine = this;
    $.getJSON(url, {"productType":productType})
    .done(function (data) {
        if (data.Result) {
            SetMachineUserSum(machine, data.UserSumRur);
            var port = productPort(productType, data.ProductCount);
            $("#" + port.ActionButton).html(data.ProductCount);
            if (data.ProductCount == 0) {
                $("#" + port.ActionButton+" + span:first").prop("disabled", true);
            }
            alert("Заберите купленный товар.");
        } else {
            alert(data.Message);
        }
    });
}

function productPort(productType, productCount) {
    var port = { ProductCount: productCount };
    
    switch(productType) {
        case 1:
            port.ActionButton = "idTea";
            break;
        case 2:
            port.ActionButton = "idCoffee";
            break;
        case 3:
            port.ActionButton = "idCoffeeAndMilk";
            break;
        case 4:
            port.ActionButton = "idJuice";
            break;
    }
    return port;
}

function PayOut() {
    var url = 'handlers/MachinePayout.ashx';
    var machine = this;
    $.getJSON(url)
    .done(function (data) {
        if (data.Result) {
            InitUserBug(data.UserBug);
            InitMachine(machine);
        } 
    });
}