using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using Nethereum.Web3;
using Nethereum.Signer;
using Nethereum.Web3.Accounts;
using Nethereum.Unity.Rpc;
using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json.Linq;

public class Web3AuthScript : MonoBehaviour
{
    Web3Auth web3Auth;
    public TextMeshProUGUI console;
    private string userEmail = "";
    private string privateKey;
    private string userInfo;
    private Account account;
    const string rpcURL = "https://ethereum-rpc.publicnode.com";
    const string sepoliaRpcURL = "https://ethereum-sepolia-rpc.publicnode.com";
    const int ethereumChainId = 1;

    // Start is called before the first frame update
    void Start()
    {
        web3Auth = GetComponent<Web3Auth>();
        var JWTLoginConfig = new LoginConfigItem()
        {
            verifier = "w3a-auth0-demo",
            clientId = "hUVVf4SEsZT7syOiL0gLU9hFEtm2gQ6O",
            typeOfLogin = TypeOfLogin.JWT,
        };
        web3Auth.setOptions(new Web3AuthOptions()
        {
            clientId = "BPi5PB_UiIZ-cPz1GtV5i1I2iOSOHuimiXBI0e-Oe_u6X3oVAbCiAZOTEBtTXw4tsluTITPqA8zMsfxIKMjiqNQ",
            redirectUrl = new System.Uri("w3aexample://com.web3auth.unityauth0example/auth"),
            network = Web3Auth.Network.SAPPHIRE_MAINNET,
            loginConfig = new Dictionary<string, LoginConfigItem>
            {
                { "jwt", JWTLoginConfig }
            }
        });
        web3Auth.onLogin += onLogin;
        web3Auth.onLogout += onLogout;
        web3Auth.onMFASetup += onMFASetup;
        web3Auth.onSignResponse += onSignResponse;

        updateConsole("Ready to Login!");
    }

    public void login()
    {
        var selectedProvider = Provider.JWT;

        var options = new LoginParams()
        {
            loginProvider = selectedProvider,
            extraLoginOptions = new ExtraLoginOptions()
            {
                domain = "https://web3auth.au.auth0.com",
                verifierIdField = "sub",
                prompt = Prompt.LOGIN,
            }
        };

        web3Auth.login(options);
    }

    private void onLogin(Web3AuthResponse response)
    {
        userInfo = JsonConvert.SerializeObject(response.userInfo, Formatting.Indented);
        privateKey = response.privKey;
        var newAccount = new Account(privateKey);
        account = newAccount;

        Debug.Log(withoutSecrets(JsonConvert.SerializeObject(response, Formatting.Indented)));
        updateConsole(JsonConvert.SerializeObject(response, Formatting.Indented));
    }

    public void getUserInfo() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        Debug.Log(withoutSecrets(userInfo));
        updateConsole(userInfo);
    }

    public void logout()
    {
        web3Auth.logout();
    }

    private void onLogout()
    {
        privateKey = null;
        userInfo = null;
        account = null;

        Debug.Log("Logged out!");
        updateConsole("Logged out!");
    }


    public void getAccount() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        Debug.Log(account.Address);
        updateConsole(account.Address);
    }

    public void getChainId() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        StartCoroutine(getChainIdRoutine());
    }

    private IEnumerator getChainIdRoutine()
    {
        var request = new NetVersionUnityRequest(rpcURL, null, null);
        yield return request.SendRequest();

        if (request.Exception != null)
        {
            Debug.Log(request.Exception.Message);
            updateConsole(request.Exception.Message);
            yield break;
        }

        Debug.Log(request.Result);
        updateConsole(request.Result);
    }

    public void getBalance() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        StartCoroutine(getBalanceRoutine());
    }

    private IEnumerator getBalanceRoutine()
    {
        var request = new EthGetBalanceUnityRequest(rpcURL, null, null);
        yield return request.SendRequest(account.Address, BlockParameter.CreateLatest());

        if (request.Exception != null)
        {
            Debug.Log(request.Exception.Message);
            updateConsole(request.Exception.Message);
            yield break;
        }

        var balance = request.Result.Value;
        Debug.Log(balance);
        updateConsole(balance.ToString());
    }

    public void signMessage() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        var msg = "wee test message 18/09/2017 02:55PM";
        var signer = new EthereumMessageSigner();
        var signature = signer.EncodeUTF8AndSign(msg, new EthECKey(privateKey));
        
        Debug.Log(signature);
        updateConsole(signature.ToString());
    }

    public void sendTransaction()
    {
        if (account == null)
        {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        StartCoroutine(sendTransactionRoutine());
    }

    private IEnumerator sendTransactionRoutine()
    {
        var toAddress = "0x2E464670992574A613f10F7682D5057fB507Cc21";

        var nonceRequest = new EthGetTransactionCountUnityRequest(rpcURL, null, null);
        yield return nonceRequest.SendRequest(account.Address, BlockParameter.CreatePending());
        if (nonceRequest.Exception != null)
        {
            Debug.Log(nonceRequest.Exception.Message);
            updateConsole(nonceRequest.Exception.Message);
            yield break;
        }

        var gasPriceRequest = new EthGasPriceUnityRequest(rpcURL, null, null);
        yield return gasPriceRequest.SendRequest();
        if (gasPriceRequest.Exception != null)
        {
            Debug.Log(gasPriceRequest.Exception.Message);
            updateConsole(gasPriceRequest.Exception.Message);
            yield break;
        }

        // Signed here rather than with Nethereum.Unity's transaction helpers, because those are
        // built against a Nethereum.Signer version that the SDK does not ship, which makes them
        // impossible to convert with IL2CPP.
        var signedTransaction = new LegacyTransactionSigner().SignTransaction(
            privateKey,
            ethereumChainId,
            toAddress,
            1,
            nonceRequest.Result.Value,
            gasPriceRequest.Result.Value,
            21000);

        var sendRequest = new EthSendRawTransactionUnityRequest(rpcURL, null, null);
        yield return sendRequest.SendRequest(signedTransaction.StartsWith("0x") ? signedTransaction : "0x" + signedTransaction);
        if (sendRequest.Exception != null)
        {
            Debug.Log(sendRequest.Exception.Message);
            updateConsole(sendRequest.Exception.Message);
            yield break;
        }

        Debug.Log(sendRequest.Result);
        updateConsole(sendRequest.Result);
    }

    public void enableMFA()
    {
        var selectedProvider = Provider.JWT;

        var options = new LoginParams()
        {
            loginProvider = selectedProvider,
            extraLoginOptions = new ExtraLoginOptions()
            {
                domain = "https://web3auth.au.auth0.com",
                verifierIdField = "sub",
                prompt = Prompt.LOGIN,
            }
        };

        web3Auth.enableMFA(options);
    }

    private void onMFASetup(bool response)
    {
        Debug.Log("MFA Setup: " + response);
    }

    public void launchWalletServices()
    {
        var chainConfig = new ChainConfig()
        {
            chainId = "0x1",
            rpcTarget = rpcURL,
            ticker = "ETH",
            chainNamespace = Web3Auth.ChainNamespace.EIP155
        };
        web3Auth.launchWalletServices(chainConfig);
    }

    public void PopupSignMessageUI()
    {
        var chainConfig = new ChainConfig()
        {
            chainId = "0xaa36a7",
            rpcTarget = sepoliaRpcURL,
            ticker = "ETH",
            chainNamespace = Web3Auth.ChainNamespace.EIP155
        };

        JArray paramsArray = new JArray
        {
             "Hello World",
             account.Address,
             "Android"
        };

        web3Auth.request(chainConfig, "personal_sign", paramsArray);
    }


    private void onSignResponse(SignResponse signResponse)

    {
        Debug.Log("Retrieved SignResponse: " + signResponse);
        updateConsole("Retrieved SignResponse: " + signResponse);
    }


    public void updateConsole(string message){
        console.text = message;
    }

    // Device logs are readable outside the app, so key material and tokens are stripped before
    // logging. The in-app console below still shows the full payload.
    private static string withoutSecrets(string json)
    {
        var payload = JObject.Parse(json);
        foreach (var field in new[] { "privKey", "ed25519PrivKey", "coreKitKey", "coreKitEd25519PrivKey", "idToken" })
            payload.Remove(field);
        (payload["userInfo"] as JObject)?.Remove("idToken");
        return payload.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}