import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { UserProfileContext } from "../providers/UserProfileProvider";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Home from "./home/home";


export default function ApplicationViews() {
  const { isLoggedIn } = useContext(UserProfileContext);

  return (
    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <Home/> : <Redirect to="/login" />}
        </Route>

        {/* <Route path={`/pose/:id`} exact>
          {isLoggedIn ? <PostureView/> : <Redirect to="/login" />}
        </Route> */}

        <Route path="/login">
          <Login />
        </Route>

        <Route path="/register">
          <Register />
        </Route>
      </Switch>
    </main>
  );
};