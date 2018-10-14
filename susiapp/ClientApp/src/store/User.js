const requestUserType = 'REQUEST_USER';
const receiveUserType = 'RECEIVE_USER';
const initialState = { user: 0, isLoading: false };

export const actionCreators = {
	requestUserById: username => async (dispatch, getState) => {
		dispatch({ type: requestUserType, username });
		const url = `api/user/getUser?username=${username}`;
		const response = await fetch(url);
		const user = await response.json();

		dispatch({ type: receiveUserType, username, user });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === requestUserType) {
		return {
			...state,
			username: action.username,
			isLoading: true
		};
	}

	if (action.type === receiveUserType) {
		return {
			...state,
			username: action.username,
			user: action.user,
			isLoading: false
		};
	}

	return state;
};
