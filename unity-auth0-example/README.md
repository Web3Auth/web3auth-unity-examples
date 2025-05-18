# Web3Auth Unity Auth0 Example

[![Web3Auth](https://img.shields.io/badge/Web3Auth-SDK-blue)](https://web3auth.io/docs/sdk/pnp/unity)
[![Web3Auth](https://img.shields.io/badge/Web3Auth-Community-cyan)](https://community.web3auth.io)

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

- Unity 2020.3 LTS or higher
- .NET 4.x or higher
- Web3Auth Dashboard Account ([Sign up here](https://dashboard.web3auth.io))
- Auth0 Account ([Sign up here](https://auth0.com))
- Platform-specific requirements:
  - iOS: Xcode 13.0+, iOS 13.0+ device
  - Android: Android Studio, Android SDK 21+
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
   - Follow the [Web3Auth Unity SDK Setup Guide](https://web3auth.io/docs/sdk/pnp/unity/installation) for installation
   - Follow the [Custom Authentication Guide](https://web3auth.io/docs/auth-provider-setup/auth0) for Auth0 setup
   - Get your Client ID from [Web3Auth Dashboard](https://dashboard.web3auth.io)
   - Open the demo scene in `Assets/Scenes/Web3AuthDemo.unity`
   - Select the Web3Auth game object
   - Configure with your Web3Auth and Auth0 credentials

## 📚 Example Implementation

The example code in this repository demonstrates:
- Web3Auth and Auth0 integration setup
- Custom authentication flow implementation
- JWT token handling and verification
- User session management
- Blockchain interaction with Auth0 authentication

Check out:
- `Assets/Scripts` directory for the implementation details
- [Web3Auth Unity Integration Guide](https://web3auth.io/docs/sdk/pnp/unity/initialize) for detailed configuration
- [Auth0 Setup Guide](https://web3auth.io/docs/auth-provider-setup/auth0) for Auth0 configuration
- [Platform Setup Guide](https://web3auth.io/docs/sdk/pnp/unity/platform-setup) for iOS, Android, and WebGL configuration

## 🤝 Support

- [Web3Auth Documentation](https://web3auth.io/docs/sdk/pnp/unity)
- [Auth0 Documentation](https://auth0.com/docs)
- [Discord](https://discord.gg/web3auth)
- [Guides](https://web3auth.io/docs/guides)

## 📝 License

MIT License 