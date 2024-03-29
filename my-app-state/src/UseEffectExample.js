import React, { useState, useEffect } from "react";
import * as UUID from "uuid";
const UseEffectExample = () => {
  const [button, setButton] = useState("");

  const [blogPosts, setBlogPosts] = useState([
    { title: "Learn useState Hook", id: 1 },
    { title: "Learn useEffect Hook", id: 2 }
  ]);
  /*
  set NODE_OPTIONS=--openssl-legacy-provider
  solution link
  https://stackoverflow.com/questions/69692842/error-message-error0308010cdigital-envelope-routinesunsupported
  */
  useEffect(() => {
    console.log("useEffect has been called!", button);
  }, [button]);

  useEffect(() => {
    console.log("useEffect has been called!", blogPosts);
  }, [blogPosts]);

  const onYesPress = () => {
    setButton("Yes");
  };

  const onNoPress = () => {
    setButton("No");
  };

  const onAddPosts = () => {
    setBlogPosts([...blogPosts, { title: "My new post", id: UUID.v4() }]);
  };

  return (
    <div>
      <button onClick={() => onYesPress()}>Yes</button>
      <button onClick={() => onNoPress()}>No</button>
      <ul>
        {blogPosts.map(blogPost => {
          return <li key={blogPost.id}>{blogPost.title}</li>;
        })}
      </ul>
      <button onClick={() => onAddPosts()}>Add Posts</button>
    </div>
  );
};

export default UseEffectExample;
