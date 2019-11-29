(function(self) {

    const config = {
        "authority": "https://cognito-idp.eu-central-1.amazonaws.com/eu-central-1_rgNLYriHz",
        "client_id": "g3i6ro2fpgu439lrp84evc3tp",
        "automaticSilentRenew": true,
        "redirect_uri": "https://localhost:5001/signed-in",
        "post_logout_redirect_uri": "/",
        "response_type": "token",
        "scope": "openid",
        "filterProtocolClaims": true,
        "loadUserInfo": false,
        "prompt": "login",
        "userStore": new Oidc.WebStorageStateStore({store: localStorage}),
        "metadata": {
            "authorization_endpoint":"https://appi-simo.auth.eu-central-1.amazoncognito.com/oauth2/authorize",
            "id_token_signing_alg_values_supported":["RS256"],
            "issuer":"https://cognito-idp.eu-central-1.amazonaws.com/eu-central-1_rgNLYriHz",
            "jwks_uri":"https://cognito-idp.eu-central-1.amazonaws.com/eu-central-1_rgNLYriHz/.well-known/jwks.json",
            "response_types_supported":["code","token","token id_token"],
            "scopes_supported":["openid","email","phone","profile"],
            "subject_types_supported":["public"],
            "token_endpoint":"https://appi-simo.auth.eu-central-1.amazoncognito.com/oauth2/token",
            "token_endpoint_auth_methods_supported":["client_secret_basic","client_secret_post"],
            "userinfo_endpoint":"https://appi-simo.auth.eu-central-1.amazoncognito.com/oauth2/userInfo",
            "end_session_endpoint": "https://appi-simo.auth.eu-central-1.amazoncognito.com/logout?logout_uri=https://localhost:5001&client_id=g3i6ro2fpgu439lrp84evc3tp&response_type=token"
        },
    };
    
    const map = (aws) => { 
        
        let map = {
            token: aws["id_token"],
            profile: {}
        };
        
        let profile = aws["profile"];
        
        map.profile = {
            sub : profile["sub"],
            address : profile["address"],
            gender : profile["gender"],
            birthdate : profile["birthdate"],
            name : profile["given_name"],
            surname : profile["family_name"],
            email : profile["email"],
            emailVerified : profile["email_verified"],
            phone : profile["phone_number"],
            phoneVerified : profile["phone_number_verified"],
        };
        
        console.log(`was: ${JSON.stringify(map)}`);

        return map;
    };

    self.authentication = {};

    self.authentication.signIn = async () => {

        const manager = new Oidc.UserManager(config);

        await manager.clearStaleState();

        const r = await manager.createSigninRequest();
        (Reflect.getPrototypeOf(r).constructor).isOidc = () => true;

        manager.signinRedirect({
            state: window.location.href,
        });
    };

    self.authentication.signedIn = async () => {

        const manager = new Oidc.UserManager(config);

        const user = await manager.signinRedirectCallback();

        // HACK: manage cognito non standard adress property
        if(user.profile && user.profile.address && user.profile.address.formatted){
            user.profile.address = user.profile.address.formatted;
        }

        return map(user);
    };

    self.authentication.tryLoadUser = async () => {

        const manager = new Oidc.UserManager(config);

        const user = await manager.getUser();
        if (!user) {
            return null;
        }

        // HACK: manage cognito non standard adress property
        if (user.profile && user.profile.address && user.profile.address.formatted) {
            user.profile.address = user.profile.address.formatted;
        }

        return map(user);
    };

    self.authentication.signOut = () => {

        const manager = new Oidc.UserManager(config);

        return manager.signoutRedirect();
    };

})(window.interop || (window.interop = {}));