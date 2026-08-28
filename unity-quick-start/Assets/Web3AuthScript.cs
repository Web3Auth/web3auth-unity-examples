using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;
using Nethereum.Web3;
using Nethereum.Util;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.ABI.Encoders;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
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

    // Start is called before the first frame update
    void Start()
    {
        // IMP START - Quick Start
        web3Auth = GetComponent<Web3Auth>();
        // IMP END - Quick Start

        // IMP START - SDK Initialization
        // IMP START - Dashboard Registration
        var clientId = "BPi5PB_UiIZ-cPz1GtV5i1I2iOSOHuimiXBI0e-Oe_u6X3oVAbCiAZOTEBtTXw4tsluTITPqA8zMsfxIKMjiqNQ"; // Get your Web3Auth Client ID on https://dashboard.web3auth.io
        // IMP END - Dashboard Registration

        web3Auth.setOptions(new Web3AuthOptions()
        {
            clientId = clientId,
            redirectUrl = new System.Uri("w3aexample://com.web3auth.unityexample/auth"),
            network = Web3Auth.Network.SAPPHIRE_MAINNET,
            
        });
        // IMP END - SDK Initialization
        // IMP START - Login
        web3Auth.onLogin += onLogin;
        // IMP END - Login
        // IMP START - Logout
        web3Auth.onLogout += onLogout;
        // IMP END - Logout
        // IMP START - Enable MFA
        web3Auth.onMFASetup += onMFASetup;
        // IMP END - Enable MFA
        // IMP START - Sign Message Popup
        web3Auth.onSignResponse += onSignResponse;
        // IMP END - Sign Message Popup

        updateConsole("Ready to Login!");
    }

    public void GrabEmailFromInputField(string input)
    {
        userEmail = input;
    }

    // IMP START - Login
    public void login()
    {
        if (userEmail == "")
        {
            Debug.Log("Please enter your email.");
            updateConsole("Please enter your email.");
            return;
        }
        var selectedProvider = Provider.EMAIL_PASSWORDLESS;

        var options = new LoginParams()
        {
            loginProvider = selectedProvider,
            extraLoginOptions = new ExtraLoginOptions()
            {
                login_hint = userEmail
            }
        };

        web3Auth.login(options);
    }

    private void onLogin(Web3AuthResponse response)
    {
        // IMP START - Get User Information
        userInfo = JsonConvert.SerializeObject(response.userInfo, Formatting.Indented);
        // IMP END - Get User Information
        // IMP START - Blockchain Calls
        privateKey = response.privKey;
        var newAccount = new Account(privateKey);
        account = newAccount;
        // IMP END - Blockchain Calls

        Debug.Log(withoutSecrets(JsonConvert.SerializeObject(response, Formatting.Indented)));
        updateConsole(JsonConvert.SerializeObject(response, Formatting.Indented));
    }
    // IMP END - Login


    public void getUserInfo()
    {
        if (account == null)
        {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        Debug.Log(withoutSecrets(userInfo));
        updateConsole(userInfo);
    }

    // IMP START - Logout
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
    // IMP END - Logout

    // IMP START - Enable MFA
    public void enableMFA()
    {
        var selectedProvider = Provider.EMAIL_PASSWORDLESS;

        var options = new LoginParams()
        {
            loginProvider = selectedProvider,
            extraLoginOptions = new ExtraLoginOptions()
            {
                login_hint = userEmail
            }
        };

        web3Auth.enableMFA(options);
    }

    private void onMFASetup(bool response)
    {
        Debug.Log("MFA Setup: " + response);
    }
    // IMP END - Enable MFA


    // IMP START - Wallet UI

    public void showWalletUI()
    {
        var chainConfig = new ChainConfig()
        {
            chainId = "0xaa36a7",
            rpcTarget = sepoliaRpcURL,
            ticker = "ETH",
            chainNamespace = Web3Auth.ChainNamespace.EIP155
        };

        web3Auth.launchWalletServices(chainConfig);
    }
    // IMP END - Wallet UI


    // IMP START - Sign Message Popup

    public void PopupSignMessageUI() {
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

    // IMP END - Sign Message Popup

    // IMP START - Blockchain Calls
    public void getAccount()
    {
        if (account == null)
        {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        Debug.Log(account.Address);
        updateConsole(account.Address);
    }

    public void getBalance()
    {
        if (account == null)
        {
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

    public void signMessage()
    {
        if (account == null)
        {
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
    // IMP END - Blockchain Calls

    public void updateConsole(string message)
    {
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