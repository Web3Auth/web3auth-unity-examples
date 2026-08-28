# Web3Auth Unity Auth0 Example

[![Web3Auth](https://img.shields.io/badge/Web3Auth_SDK-7.0.2-blue)](https://github.com/Web3Auth/web3auth-unity-sdk/releases/tag/7.0.2)

This example demonstrates how to integrate Web3Auth with Auth0 in a Unity application. It shows how to use Auth0 as a custom authentication provider with Web3Auth, combining Auth0's powerful authentication features with Web3Auth's blockchain capabilities.

## 🎮 Key Features

- Auth0 integration with Web3Auth
- Custom authentication flow
- JWT token handling
- Role-based access control (RBAC)
- Single Sign-On (SSO) support
- Multiple social login providers through Auth0
- Secure session management

## 📋 Prerequisites

- Unity 6.3 LTS (`6000.3.22f1`)
- Web3Auth Unity SDK 7.0.2 (included under `Assets/Plugins/Web3AuthSDK`)
- A [MetaMask Developer Dashboard](https://developer.metamask.io/) Embedded Wallets project
- Auth0 Account ([Sign up here](https://auth0.com))
- Platform-specific requirements:
  - iOS: Xcode and an iOS 13.0+ device
  - Android: Android SDK 24+
  - WebGL: Modern browser with Web3 support

## 🚀 Getting Started

1. Clone this example:
```bash
git clone https://github.com/Web3Auth/web3auth-unity-examples.git
cd web3auth-unity-examples/unity-auth0-example
```

2. Open in Unity:
   - Launch Unity Hub
   - Click "Add project from disk"
   - Select the `unity-auth0-example` directory
   - Open the project

3. Configure Web3Auth and Auth0:
   - Create an Auth0 connection in the Embedded Wallets dashboard
   - Open `Assets/Web3Auth-Example.unity`
   - Configure the Web3Auth client ID, Auth0 domain/client ID, and connection ID in `Assets/Web3AuthScript.cs`
   - Allowlist `w3aexample://com.web3auth.unityauth0example/auth` in the dashboard

## 📚 Example Implementation

The example code in this repository demonstrates:
- Web3Auth and Auth0 integration setup
- Custom authentication flow implementation
- JWT token handling and verification
- User session management
- Blockchain interaction with Auth0 authentication

The implementation is in `Assets/Web3AuthScript.cs`. See [Unity custom authentication](https://docs.metamask.io/embedded-wallets/sdk/unity/advanced/custom-authentication/) for connection setup.

## 🤝 Support

- [Unity SDK Documentation](https://docs.metamask.io/embedded-wallets/sdk/unity/)
- [Auth0 Documentation](https://auth0.com/docs)
- [Builder Hub](https://builder.metamask.io/c/embedded-wallets/5)

## 📝 License

MIT License 