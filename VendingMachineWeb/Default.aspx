<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VendingMachineWeb.Default" %>

<%@ Import Namespace="Newtonsoft.Json" %>
<%@ Import Namespace="VendingMachineEngine.Enums" %>
<%@ Import Namespace="VendingMachineEngine.Model" %>
<%@ Import Namespace="VendingMachineWeb.Managers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/vmachine.js"></script>
    <link href="CSS/main_style.css" rel="stylesheet" />
    <title></title>
    <script type="text/javascript">
        var userBug = <%=WriteUserBugToJs()%>;
        userBug.PayCoin = PayCoin;
        userBug.AddCoin = AddCoin;
        userBug.RemoveCoin = RemoveCoin;
        
        var machine = <%=WriteMachineToJs()%>;
        machine.BuyProduct = BuyProduct;
        machine.PayOut = PayOut;
        var oneRuble=<%=JsonConvert.SerializeObject(new CoinModel{Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble}, Formatting.Indented)%>;
        var twoRuble=<%=JsonConvert.SerializeObject(new CoinModel{Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble}, Formatting.Indented)%>;
        var fiveRuble=<%=JsonConvert.SerializeObject(new CoinModel{Value = CoinValueEnum.Five, CoinType = CoinTypeEnum.Ruble}, Formatting.Indented)%>;
        var tenRuble=<%=JsonConvert.SerializeObject(new CoinModel{Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble}, Formatting.Indented)%>;
        
        $(document).ready(function() {
            InitUserBug(userBug);
            InitMachine(machine);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="centerLayer" class="item_container">
            <div id="idUserBugBox">
                <h2>Кошелек пользователя</h2>
                <div>1 рубль <span class="count-box"><span class="tovar-count" id="idUserBugOne"></span>мон.</span><span class="buy-box" onclick="javascript: userBug.PayCoin(oneRuble, machine);">внести</span></div>
                <div>2 рубля <span class="count-box"><span class="tovar-count" id="idUserBugTwo"></span>мон.</span><span class="buy-box" onclick="javascript: userBug.PayCoin(twoRuble, machine);">внести</span></div>
                <div>5 рублей <span class="count-box"><span class="tovar-count" id="idUserBugFive"></span>мон.</span><span class="buy-box" onclick="javascript: userBug.PayCoin(fiveRuble, machine);">внести</span></div>
                <div>10 рублей <span class="count-box"><span class="tovar-count" id="idUserBugTen"></span>мон.</span><span class="buy-box" onclick="javascript: userBug.PayCoin(tenRuble, machine);">внести</span></div>
            </div>
            <div id="idVmMBox">
                <h2>Кофе-машина</h2>
                <div class="left-col">
                    <div class="product-box">
                        <div class="product-box-item">Чай <span><%=MachineMemoryManager.Instance().TeaPort.ItemPrice %> рублей</span></div>  
                        <span class="tovar-count" id="idTea"></span><span class="tovar-count">штук</span>
                        <span class="buy-box" onclick="machine.BuyProduct(machine.TeaPort.ProductType);">купить</span>
                    </div>
                    <div class="product-box">
                        <div class="product-box-item">Кофе <span><%=MachineMemoryManager.Instance().CoffeePort.ItemPrice %> рублей</span>
                            </div>
                         <span class="tovar-count" id="idCoffee"></span><span class="tovar-count">штук</span>
                        <span class="buy-box" onclick="machine.BuyProduct(machine.CoffeePort.ProductType);">купить</span>
                    </div>
                    <div class="product-box">
                        <div class="product-box-item">Кофе с молоком <span><%=MachineMemoryManager.Instance().CoffeeAndMilkPort.ItemPrice %> рубль</span>
                            </div>
                        <span class="tovar-count" id="idCoffeeAndMilk"></span><span class="tovar-count">штук</span>
                        <span class="buy-box" onclick="machine.BuyProduct(machine.CoffeeAndMilkPort.ProductType);">купить</span>
                    </div>
                    <div class="product-box">
                        <div class="product-box-item">Сок <span><%=MachineMemoryManager.Instance().JuicePort.ItemPrice %> рублей</span></div> 
                        <span class="tovar-count" id="idJuice"></span><span class="tovar-count">штук</span>
                        <span class="buy-box" onclick="machine.BuyProduct(machine.JuicePort.ProductType);">купить</span>
                    </div>
                </div>
                <div class="right-col">
                    <div>Полученная сумма: <span class="user-sum-box" id="idMachineUserBug"></span> </div>
                    <div><span class="buy-box" id="idPayOut" onclick="machine.PayOut();" >получить сдачу</span></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
